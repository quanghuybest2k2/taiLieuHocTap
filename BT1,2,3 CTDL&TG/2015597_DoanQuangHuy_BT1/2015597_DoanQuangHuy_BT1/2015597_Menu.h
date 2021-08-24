#pragma once
void XuatMenu()
{
	cout << "_____________MENU TUY CHON_____________";
	cout << "\n0. Thoat khoi chuong trinh!";
	cout << "\n1. Tao danh sach hoc vien";
	cout << "\n2. Xem danh sach hoc vien";
	cout << "\n3. Tim kiem theo lop va so tin chi";
	cout << "\n4. Tim kiem theo ten cho truoc";
	cout << "\n5. Tim kiem theo nam sinh va diem trung binh";
	cout << "\n_______________________________________\n";
}
int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("cls");
		XuatMenu();
		cout << "Moi ban chon chuc nang >> ";
		cin >> stt;
		if (stt >= 0 && stt <= soMenu)
			break;
	}
	return stt;
}
void XuLyMenu(int stt, HocVien a[], int& n)
{
	int check;
	char* filename;
	char lopNhap[6];
	int soTinNhap;
	char tenNhap[7];
	int namSinhNhap;
	double diemTrungBinhNhap;
	system("cls");
	switch (stt)
	{
	case 0:
		cout << "\nOK. CHUONG TRINH DA THOAT!!!\n";
		break;
	case 1:
		filename = new char[MAX];
		do
		{
			cout << "\n1. Tao danh sach nhan vien\n";
			cout << "Nhap file .txt: ";
			cin >> filename;
			check = TaoDanhSachHocVien(a, n, filename);
		} while (!check);

		cout << "\nDa mo tap tin " << filename << " thanh cong\n";
		delete[] filename;
		break;
	case 2:
		cout << "\n2. Xem danh sach nhan vien\n";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		break;
	case 3:
		cout << "\n3. Tim kiem theo lop va so tin chi";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		cout << "\nNhap ten lop: ";
		cin >> lopNhap;
		cout << "\nNhap so tin chi: ";
		cin >> soTinNhap;
		XuatDanhSach_HV_Lop_TinChi(a, n, lopNhap, soTinNhap);
		break;
	case 4:
		cout << "\n4. Tim kiem theo ten cho truoc";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
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
	_getch();
}