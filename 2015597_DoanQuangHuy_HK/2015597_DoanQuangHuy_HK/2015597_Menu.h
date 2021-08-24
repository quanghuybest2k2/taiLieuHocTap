#pragma once

// Khai báo nguyên mẫu hàm:
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(BSTree& root, int stt);

// Hiển thị Menu
void XuatMenu()
{
	cout << endl << " ----------------- CAY NHI PHAN TIM KIEM BST ----------------- ";
	cout << endl << " 0. Thoat khoi chuong trinh";
	cout << endl << " 1. Tao bang luong nhan vien (tu file bangluong.txt)";
	cout << endl << " 2. Xem danh sach nhan vien theo thu tu giua (LNR)";
	cout << endl << " 3. Tinh so nut cua cay";
	cout << endl << " 4. Xuat thong tin nhan vien co ma nhan vien la LD19002";
	cout << endl << " 5. Sua thong tin nam sinh cua nhan vien co man vien la LD18041 thanh 1990";
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
	int kq;
	char file[]{ "bangluong.txt" }; // tên file
	switch (stt)
	{
	case 0:
	{
		exit(1);
	}
	case 1:
	{
		kq = ReadFile(root, file);
		if (kq == 1)
			cout << endl << "Nhap file " << file << " thanh cong!";
		else
			cout << endl << "Loi nhap file!";
		break;
	}
	case 2:
	{
		cout << endl << "\t\t\tDANH SACH NHAN VIEN";
		TieuDe();
		LNR(root);
		break;
	}
	case 3:
	{
		cout << endl << "\t\t\tDANH SACH NHAN VIEN";
		TieuDe();
		LNR(root);
		int kq = Count(root);
		cout << "\nTong so nut cua cay la: " << kq << endl;
		break;
	}
	case 4:
	{
		cout << endl << "\t\t\tDANH SACH NHAN VIEN";
		TieuDe();
		LNR(root);
		KeyType x = "LD19022";
		TieuDe();
		XuatThongTinNhanVienTheoMaNhanVien(root, x);
		break;
	}
	case 5:
	{
		cout << endl << "\t\t\tDANH SACH NHAN VIEN";
		TieuDe();
		LNR(root);
		KeyType y = "LD18041";
		int namSinh = 1990;
		SuaThongTinNhanVien(root, y, namSinh);
		cout << endl << "\t\t\tDANH SACH NHAN VIEN";
		TieuDe();
		LNR(root);
		break;
	}
	default:
		break;
	}
	cout << endl;
	system("pause");
}