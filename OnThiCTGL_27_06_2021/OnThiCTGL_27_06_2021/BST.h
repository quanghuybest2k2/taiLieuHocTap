
#include <iostream>
#include <conio.h>
#include <iomanip>
#include <fstream>
using namespace std;

#define MAX_COT 79

typedef char KeyType[8];
// Cấu trúc dữ liệu học viên
struct HocVien
{
	KeyType maHocVien;
	char ho[10];
	char hoLot[10];
	char ten[10];
	char lop[5];
	int namSinh;
	float diemTB;
	int soTin;
};

// Định nghĩa cấu trúc cây nhị phân tìm kiếm
struct BSNode
{
	HocVien info;
	BSNode* pLeft;
	BSNode* pRight;
};

typedef BSNode* BSTree;
// =================================================================================================
// Khai báo nguyên mẫu hàm:
BSNode* CreateNode(HocVien x);
int InsertNode(BSTree& root, HocVien x);
int ReadFile(BSTree& root, char* file);
void KeNgang(char kt);
void TieuDe();
void Xuat1HocVien(HocVien p);
void NLR(BSTree root);

// Khởi tạo node
BSNode* CreateNode(HocVien x)
{
	BSNode* p = new BSNode;
	if (p != NULL)
	{
		p->info = x;
		p->pLeft = p->pRight = NULL;
	}
	return p;
}

// Thêm node vào cây
int InsertNode(BSTree& root, HocVien x)
{
	// Trường hợp cây đã tồn tại phần tử
	if (root != NULL)
	{
		if (_strcmpi(root->info.maHocVien, x.maHocVien) == 0)
			return 0;
		if (_strcmpi(root->info.maHocVien, x.maHocVien) < 0)
			return InsertNode(root->pRight, x);
		else
			return InsertNode(root->pLeft, x);
	}
	// Trường hợp cây rỗng
	root = CreateNode(x); // Khởi tạo Node cho cây
	if (root == NULL) return -1;
	return 1;
}

// Đọc dữ liệu từ file
int ReadFile(BSTree& root, char* file)
{
	ifstream in(file);
	if (!in) return 0;
	root = NULL;
	int kq;
	HocVien x;
	while (!in.eof())
	{
		in >> x.maHocVien;
		in >> x.ho;
		in >> x.hoLot;
		in >> x.ten;
		in >> x.lop;
		in >> x.namSinh;
		in >> x.diemTB;
		in >> x.soTin;
		kq = InsertNode(root, x);
		if (kq == 0 || kq == -1) return 0;
	}
	in.close();
	return 1;
}

void KeNgang(char kt)
{
	cout << '|';
	for (int i = 0; i < MAX_COT; i++)
	{
		cout << kt;
	}
	cout << '|';
}
void TieuDe()
{
	cout << endl;
	KeNgang('=');
	cout << setiosflags(ios::left) << endl << '|'
		<< setw(8) << "Ma HV" << '|'
		<< setw(10) << "Ho" << '|'
		<< setw(10) << "Ho lot" << '|'
		<< setw(10) << "Ten" << '|'
		<< setw(8) << "Lop" << '|'
		<< setw(8) << "NS" << '|'
		<< setw(8) << "Diem TB" << '|'
		<< setw(10) << "So tin" << '|' << endl;
	KeNgang('=');
}

void Xuat1HocVien(HocVien p)
{
	cout << setiosflags(ios::left) << endl << '|'
		<< setw(8) << p.maHocVien << '|'
		<< setw(10) << p.ho << '|'
		<< setw(10) << p.hoLot << '|'
		<< setw(10) << p.ten << '|'
		<< setw(8) << p.lop << '|'
		<< setw(8) << p.namSinh << '|'
		<< setw(8) << p.diemTB << '|'
		<< setw(10) << p.soTin << '|' << endl;
	KeNgang('-');
}

// Duyệt cây theo Node - Left - Right
void NLR(BSTree root)
{
	if (root != NULL)
	{
		Xuat1HocVien(root->info);
		NLR(root->pLeft);
		NLR(root->pRight);
	}
}
