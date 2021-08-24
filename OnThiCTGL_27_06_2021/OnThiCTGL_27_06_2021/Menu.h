
#include "Header.h"
// Khai báo nguyên mẫu hàm:
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(BSTree& root, int stt);

// Hiển thị Menu
void XuatMenu()
{
	cout << endl << " ----------------- CAY NHI PHAN TIM KIEM BST ----------------- ";
	cout << endl << " 0. Thoat khoi chuong trinh";
	cout << endl << " 1. Nhap du lieu";
	cout << endl << " 2. Xem danh sach hoc vien";
	cout << endl << " 3. Sua so tin chi tich luy cua hoc vien co ma hoc vien X thanh 35";
	cout << endl << " 4. Xoa hoc vien co ma hoc vien X ra khoi danh sach hoc vien";
	cout << endl << " 5. Xuat danh sach hoc vien theo lop";
	cout << endl << " 6. Tim kiem hoc vien theo ma hoc vien";
	cout << endl << " ------------------------------------------------------------- ";
}

// Cho người dùng chọn 1 chức năng
int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("cls");
		XuatMenu();
		cout << endl << "Nhap tuy chon (0->" << soMenu << "): ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu) break;
	}
	return stt;
}

// Xử lý từng chức năng
void XuLyMenu(BSTree& root, int stt)
{
	int kq, kt;
	char file; // tên file
	int soTin = 35;
	KeyType x, y, z;
	switch (stt)
	{
	case 0:
	{
		exit(1);
	}
	case 1:
	{
		kq = ReadFile(root, file); // Ở đây mình lười nên cho thằng luôn tên file
		// Bạn có thể sửa thành nhập file.
		if (kq == 1)
			cout << endl << "Nhap file " << file << " thanh cong!";
		else
			cout << endl << "Loi nhap file!";
		break;
	}
	case 2:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		NLR(root);
		break;
	}
	case 3:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		NLR(root);
		cout << endl << "Nhap ma hoc vien can sua doi tin chi thanh 35: ";
		cin >> x;
		SuaDoiTinChi(root, x, soTin);
		cout << endl << "\t\t\tDANH SACH HOC VIEN SAU KHI SUA DOI TIN CHI";
		TieuDe();
		NLR(root);
		break;
	}
	case 4:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		NLR(root);
		cout << endl << "Nhap ma hoc vien can xoa: ";
		cin >> y;
		kt = DelNode(root, y);
		if (kt == 1)
		{
			cout << endl << "Xoa thanh cong!";
			cout << endl << "\t\t\tDANH SACH HOC VIEN SAU KHI XOA";
			TieuDe();
			NLR(root);
		}
		else
			cout << endl << "Ma " << y << " khong ton tai, kiem tra lai!";
		break;
	}
	case 5:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		NLR(root);
		cout << endl << "\t\t\tDANH SACH HOC VIEN LOP CTK36";
		TieuDe();
		LayDanhSachLopCTK36(root);
		break;
	}
	case 6:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		NLR(root);
		cout << endl << "Nhap ma hoc vien can tim kiem: ";
		cin >> z;
		BSNode* p = Search(root, z);
		if (p != NULL)
		{
			cout << endl << "Tim thay hoc vien co ma hoc vien: " << z << " trong cay";
			cout << endl << "Thong tin cua hoc vien: " << z << " la: " << endl;
			TieuDe();
			Xuat1HocVien(p->info);
		}
		else
			cout << endl << "Khong tim thay ma hoc vien: " << z << ", vui long kiem tra lai!";
		break;
	}
	default:
		break;
	}
	cout << endl;
	system("pause");
}