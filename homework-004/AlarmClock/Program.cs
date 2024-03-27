using System;
using System.Threading;

// 定义委托类型
public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

// 定义闹钟事件的参数类
public class AlarmEventArgs : EventArgs
{
    public DateTime Time { get; }

    public AlarmEventArgs(DateTime time)
    {
        Time = time;
    }
}

// 定义闹钟类
public class AlarmClock
{
    // 声明一个事件
    public event AlarmEventHandler Alarm;

    // 触发闹钟事件的方法
    protected virtual void OnAlarm(DateTime time)
    {
        Alarm?.Invoke(this, new AlarmEventArgs(time));
    }

    // 设置闹钟的方法
    public void SetAlarm(DateTime alarmTime)
    {
        // 计算距离闹钟响铃的时间
        TimeSpan timeUntilAlarm = alarmTime - DateTime.Now;

        // 创建一个计时器，等待时间到达后触发事件
        Timer timer = new Timer(_ =>
        {
            OnAlarm(alarmTime);
        }, null, (int)timeUntilAlarm.TotalMilliseconds, Timeout.Infinite);
    }
}

// 主程序入口
class Program
{
    static void Main(string[] args)
    {
        // 创建一个闹钟实例
        AlarmClock alarmClock = new AlarmClock();

        // 订阅闹钟事件
        alarmClock.Alarm += AlarmHandler;

        // 设置闹钟时间为当前时间的5秒后
        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        alarmClock.SetAlarm(alarmTime);

        // 等待闹钟响铃
        Console.WriteLine("等待闹钟响铃...");
        Console.ReadLine();
    }

    // 处理闹钟事件的方法
    static void AlarmHandler(object sender, AlarmEventArgs e)
    {
        Console.WriteLine($"闹钟响铃时间：{e.Time}");
        Console.WriteLine("时间到了！该起床了！");
    }
}
