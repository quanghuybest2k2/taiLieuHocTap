void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, HocVien a[MAX], int& n);

void XuatMenu()
{
	cout << "\n=================================HE THONG CHUC NANG===============================";
	cout << "\n0. Thoat chuong trinh";
	cout << "\n1. Tao danh sach hoc vien";
	cout << "\n2. Xem danh sach hoc vien";
	cout << "\n3. Chuc nang 3";
	cout << "\n4. Chuc nang 4";
	cout << "\n5. Chuc nang 5";
}

int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("cls"); // clears man hinh
		XuatMenu();
		cout << "\nMoi ban chon chuc nang: ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;
}

void XuLyMenu(int menu, HocVien a[MAX], int& n)
{
	char* f;
	int kq;
	char lopNhap[7];
	int soTCNhap;
	char tenNhap[7];
	int namSinhNhap;
	double diemTrungBinhNhap;
	switch (menu)
	{
	case 0:
		system("cls");
		cout << "\nDa thoat chuong trinh!\n";
		break;
	case 1:
		system("cls");
		cout << "\nTao bang diem mon hoc\n";
		f = new char[MAX];
		do
		{
			cout << "\nMoi nhap ten tap tin: ";
			cin >> f;
			kq = Chuyen_TT_BD(f, a, n);
		} while (!kq);
		cout << "\nDa chuyen thanh cong tap tin " << f << " vao bang diem\n";
		delete[]f;
		break;
	case 2:
		system("cls");
		cout << "\nBang diem mon hoc\n";
		XuatBD(a, n);
		cout << "\nSo hoc vien trong bang diem la: " << n;
		break;
	case 3:
		system("cls");
		cout << "\n\n";

		break;
	case 4:
		cout << "\n\n";

		break;
	case 5:
		cout << "\n\n";

		break;
	}
}