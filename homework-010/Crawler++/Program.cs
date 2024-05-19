using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrawler
{
    public class SimpleCrawler
    {
        private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();
        private int count = 0;
        private string startUrl;
        private string domain;
        public Action<string> OnCrawlStart;
        public Action<string> OnCrawlFinish;
        public Action<string> OnError;

        public SimpleCrawler(string startUrl)
        {
            this.startUrl = startUrl;
            this.domain = new Uri(startUrl).Host;
            urls.TryAdd(startUrl, false);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CrawlerForm());
        }

        public async Task Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            List<Task> tasks = new List<Task>();

            while (true)
            {
                string current = null;

                foreach (var url in urls.Keys)
                {
                    if (urls[url]) continue;
                    current = url;
                    break;
                }

                if (current == null || count > 10) break;

                OnCrawlStart?.Invoke($"爬行 {current} 页面!");
                tasks.Add(Task.Run(async () => await CrawlPage(current)));

                count++;
                await Task.WhenAll(tasks);
            }
        }

        private async Task CrawlPage(string current)
        {
            string html = await DownLoad(current); // 下载
            urls[current] = true;
            Parse(html, current); // 解析，并加入新的链接
            OnCrawlFinish?.Invoke($"爬行结束 {current}");
        }

        public async Task<string> DownLoad(string url)
        {
            try
            {
                using WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = await webClient.DownloadStringTaskAsync(url);
                string fileName = count.ToString();
                await File.WriteAllTextAsync(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"错误: {ex.Message}");
                return "";
            }
        }

        private void Parse(string html, string pageUrl)
        {
            string strRef = @"(href|HREF)[\s]*=[\s]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;

                // 处理相对地址
                strRef = ConvertToAbsoluteUrl(strRef, pageUrl);

                // 只爬取与起始地址域名相同的网页
                Uri uri = new Uri(strRef);
                if (uri.Host != domain) continue;

                // 只爬取 htm/html/aspx/php/jsp 网页
                if (!Regex.IsMatch(uri.AbsolutePath, @"\.(htm|html|aspx|php|jsp)$")) continue;

                urls.TryAdd(strRef, false);
            }
        }

        private string ConvertToAbsoluteUrl(string relativeUrl, string baseUrl)
        {
            Uri baseUri = new Uri(baseUrl);
            Uri absoluteUri = new Uri(baseUri, relativeUrl);
            return absoluteUri.ToString();
        }
    }

    public partial class CrawlerForm : Form
    {
        private SimpleCrawler crawler;
        private TextBox urlTextBox;
        private Button startButton;
        private ListBox resultListBox;
        private ListBox errorListBox;

        public CrawlerForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.urlTextBox = new TextBox();
            this.startButton = new Button();
            this.resultListBox = new ListBox();
            this.errorListBox = new ListBox();

            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(12, 12);
            this.urlTextBox.Size = new System.Drawing.Size(500, 20);
            this.urlTextBox.Text = "http://www.cnblogs.com/dstang2000/";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(520, 10);
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.Text = "Start";
            this.startButton.Click += new EventHandler(this.StartButton_Click);
            // 
            // resultListBox
            // 
            this.resultListBox.Location = new System.Drawing.Point(12, 50);
            this.resultListBox.Size = new System.Drawing.Size(583, 200);
            // 
            // errorListBox
            // 
            this.errorListBox.Location = new System.Drawing.Point(12, 260);
            this.errorListBox.Size = new System.Drawing.Size(583, 200);
            // 
            // CrawlerForm
            // 
            this.ClientSize = new System.Drawing.Size(607, 475);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.errorListBox);
            this.Text = "Simple Crawler";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string startUrl = urlTextBox.Text;
            crawler = new SimpleCrawler(startUrl);
            crawler.OnCrawlStart += url => resultListBox.Invoke(new Action(() => resultListBox.Items.Add(url)));
            crawler.OnCrawlFinish += url => resultListBox.Invoke(new Action(() => resultListBox.Items.Add(url)));
            crawler.OnError += error => errorListBox.Invoke(new Action(() => errorListBox.Items.Add(error)));
            Task.Run(() => crawler.Crawl());
        }
    }
}
