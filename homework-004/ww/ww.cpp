#include <iostream>
#include <fstream>
#include <string>

using namespace std;

// 图书信息结构体定义
struct Book {
    string id;    // ISBN
    string name;  // 书名
    double price; // 定价
};

// 顺序表的定义
struct SqList {
    Book* elem; // 存储空间的基地址
    int length; // 当前长度
    int capacity; // 当前容量
};

// 创建空顺序表
SqList createEmptySqList(int capacity) {
    SqList list;
    list.elem = new Book[capacity];
    list.length = 0;
    list.capacity = capacity;
    return list;
}

// 输入顺序表图书信息
void inputSqList(SqList& list, const string& filename) {
    ifstream file(filename);
    if (!file) {
        cerr << "Error: Unable to open file: " << filename << endl;
        return;
    }
    string s;
    file >> s;
    file >> s;  file >> s; 
    string isbn, name;
    double price;
    while (file >> isbn >> name >> price && list.length < list.capacity) {
        list.elem[list.length].id = isbn;
        list.elem[list.length].name = name;
        list.elem[list.length].price = price;
        list.length++;
    }

    file.close();
}


// 查找顺序表中给定位置的图书信息
Book findBookAtPosition(const SqList& list, int position) {
    if (position < 1 || position > list.length) {
        cerr << "Error: Invalid position" << endl;
        return { "", "", 0.0 }; // 返回空的Book结构体
    }
    return list.elem[position - 1];
}

// 查找图书对应的价格
double findBookPrice(const SqList& list, const string& isbn) {
    for (int i = 0; i < list.length; ++i) {
        if (list.elem[i].id == isbn) {
            return list.elem[i].price;
        }
    }
    cerr << "Error: Book with ISBN " << isbn << " not found" << endl;
    return -1.0; // 表示未找到
}

// 在给定位置，插入图书信息
void insertBookAtPosition(SqList& list, int position, const Book& book) {
    if (position < 1 || position > list.length + 1 || list.length == list.capacity) {
        cerr << "Error: Invalid position or list is full" << endl;
        return;
    }

    for (int i = list.length; i >= position; --i) {
        list.elem[i] = list.elem[i - 1];
    }

    list.elem[position - 1] = book;
    list.length++;
}

// 指定位置，删除图书信息
void deleteBookAtPosition(SqList& list, int position) {
    if (position < 1 || position > list.length) {
        cerr << "Error: Invalid position" << endl;
        return;
    }

    for (int i = position - 1; i < list.length - 1; ++i) {
        list.elem[i] = list.elem[i + 1];
    }

    list.length--;
}

// 显示当前顺序表中所有图书信息
void displaySqList(const SqList& list) {
    cout << "ISBN\t\tBook Name\t\tPrice" << endl;
    for (int i = 0; i < list.length; ++i) {
        cout << list.elem[i].id << "\t\t" << list.elem[i].name << "\t\t" << list.elem[i].price << endl;
    }
}

int main() {
    // 创建空顺序表
    int capacity;
    cout << "Enter the capacity of the list: ";
    cin >> capacity;
    SqList books = createEmptySqList(capacity);

    // 输入顺序表图书信息
    string filename;
    cout << "Enter the filename to read book information from: ";
    cin >> filename;
    inputSqList(books, filename);

    // 显示当前顺序表中所有图书信息
    cout << "Current book list:" << endl;
    displaySqList(books);

    // 示例操作：查找图书信息
    int position;
    cout << "Enter the position of the book to find: ";
    cin >> position;
    Book bookAtPos = findBookAtPosition(books, position);
    cout << "Book at position " << position << ": ";
    if (bookAtPos.id != "") {
        cout << bookAtPos.id << ", " << bookAtPos.name << ", " << bookAtPos.price << endl;
    }

    // 示例操作：查找图书价格
    string isbn;
    cout << "Enter the ISBN of the book to find its price: ";
    cin >> isbn;
    double price = findBookPrice(books, isbn);
    if (price != -1.0) {
        cout << "Price of book with ISBN '" << isbn << "': " << price << endl;
    }

    // 示例操作：在指定位置插入图书信息
    Book newBook;
    cout << "Enter the ISBN, name, and price of the new book to insert: ";
    cin >> newBook.id >> newBook.name >> newBook.price;
    cout << "Enter the position to insert the new book: ";
    cin >> position;
    insertBookAtPosition(books, position, newBook);
    displaySqList(books);

    // 示例操作：删除指定位置的图书信息
    cout << "Enter the position of the book to delete: ";
    cin >> position;
    deleteBookAtPosition(books, position);
    displaySqList(books);

    delete[] books.elem; // 释放动态分配的内存
    return 0;
}