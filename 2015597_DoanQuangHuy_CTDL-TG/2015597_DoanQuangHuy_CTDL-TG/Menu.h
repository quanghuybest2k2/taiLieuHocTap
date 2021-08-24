void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, HocVien a[MAX], int& n);

void XuatMenu()
{
	cout << "\n=================================HE THONG CHUC NANG===============================";
	cout << "\n0. Thoat chuong trinh";
	cout << "\n1. Tao danh sach hoc vien";
	cout << "\n2. Xem danh sach hoc vien";
	cout << "\n3. Tim kiem theo lop va so tin chi: Xuat hoc vien thuoc lop CTK37 co so tin chi tich luy > 41";
	cout << "\n4. Tim kiem theo ten";
	cout << "\n5. Tim kiem theo nam sinh va diem trung binh: xuat cac hoc vien co nam sinh > 1993 va co diem trung binh <= 6.2";
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
		cout << "Da chuyen thanh cong tap tin " << f << " vao bang diem";
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
		cout << "\nTim kiem theo lop va so tin chi\n";
		cout << "\n\t\tDANH SACH HOC VIEN\t\t\n";
		XuatBD(a, n);
		cout << "\nNhap ten lop: ";
		cin >> lopNhap;
		cout << "\nNhap so tin chi: ";
		cin >> soTCNhap;
		TimTheoLopVaTC(a, n, lopNhap, soTCNhap);
		break;
	case 4:
		cout << "\n4. Tim kiem theo ten cho truoc";
		cout << "\n\n\t\t\t\tDANH SACH HOC VIEN\n";
		XuatBD(a, n);
		cout << "\nNhap ten hoc vien muon tim kiem: ";
		cin >> tenNhap;
		TimKiemTheoTen(a, n, tenNhap);
		break;
	case 5:
		cout << "\n5. Tim kiem theo nam sinh va diem trung binh";
		cout << "\nNhap nam sinh: ";
		cin >> namSinhNhap;
		cout << "\nNhap diem trung binh: ";
		cin >> diemTrungBinhNhap;
		TimKiem_HV_TheoNamSinh_DiemTrungBinh(a, n, namSinhNhap, diemTrungBinhNhap);
		break;
	}
}