void XuatMenu()
{
	cout << "================= MENU TUY CHON =================";
	cout << "\n0. Thoat khoi chuong trinh!";
	cout << "\n1. Tao danh sach hoc vien";
	cout << "\n2. Xem danh sach hoc vien";
	cout << "\n3. Sap danh sach hoc vien tang dan theo ma hoc vien (Chon truc tiep)";
	cout << "\n4. Sap danh sach hoc vien tang dan theo ma ho vien (Quick Sort)";
	cout << "\n5. Sap xep theo yeu cau";
	cout << "\n==============================================\n";
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
	system("cls");
	switch (stt)
	{
	case 0:
		cout << "\nOK. CHUONG TRINH DA THOAT!!!\n";
		return;
	case 1:
		filename = new char[MAX];
		do
		{
			cout << "\n1. Tao danh sach nhan vien\n";
			cout << "Nhap file .txt: ";
			cin >> filename;
			check = TaoDanhSachHocVien(a, n, filename);
		} while (!check);

		cout << "\nDa mo tap tin " << filename << " thanh cong!!!\n";
		delete[] filename;
		break;
	case 2:
		cout << "\n2. Xem danh sach nhan vien\n";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		break;
	case 3:
		cout << "\n3. Sap danh sach hoc vien tang dan theo ma hoc vien (Chon truc tiep)";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		cout << "\nDANH SACH HOC VIEN SAU KHI SAP XEP\n";
		Selection_L(a, n);
		Xuat_DanhSach_HV(a, n);

		break;
	case 4:
		cout << "\n4. Sap danh sach hoc vien tang dan theo ma ho vien (Quick Sort)";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		cout << "\nDANH SACH HOC VIEN SAU KHI SAP XEP\n";
		QuickSort(a, n);
		Xuat_DanhSach_HV(a, n);

		break;
	case 5:
		cout << "\n5. Sap xep theo yeu cau";
		cout << "\n\n\t\t\t\tDANH SACH NHAN VIEN\n";
		Xuat_DanhSach_HV(a, n);
		cout << "\nDANH SACH HOC VIEN SAU KHI SAP XEP\n";
		SapXepTheoYeuCau(a, n);
		Xuat_DanhSach_HV(a, n);
		break;
	}
	cout << "\nNhan mot phim de tiep tuc chuong trinh!";
	_getch();
}