void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, BSTree& root);
void XuatMenu()
{
	cout << endl << " ----------------- CAY NHI PHAN TIM KIEM BST ----------------- ";
	cout << endl << " 0. Thoat khoi chuong trinh";
	cout << endl << " 1. Tao bang luong nhan vien";
	cout << endl << " 2. Xem bang luong nhan vien (LNR)";
	cout << endl << " 3. Tinh so nut cua cay";
	cout << endl << " 4. Xuat thong tin nhan vien co ma nhan vien la LD19022";
	cout << endl << " 5. Sua thong tin nam sinh cua nhan vien co ma nhan vien LD18041 thanh 1990";
	cout << endl << " ------------------------------------------------------------- ";
}

int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("CLS");
		XuatMenu();
		cout << "Chon chuc nang tu 0 den " << soMenu << " den chon chuc nang: ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;
}

void XuLyMenu(int menu, BSTree& root)
{
	char* filename;
	int kq;
	char maHV[8];
	char ten[8];
	KeyType z;
	//BSNode* p;
	system("CLS");
	switch (menu)
	{
	case 0:
		cout << "\0. Thoat khoi chuong trinh\n";
		return;
	case 1:
		cout << "\n1. Tao cay BST";
		filename = new char[50];
		do
		{
			cout << "\nNhap filename = ";
			cin >> filename;
			kq = File_BST(root, filename);
		} while (kq == 0);
		cout << "\nDa chuyen du lieu tap tin " << filename << " vao BSTree thanh cong.";
		delete[]filename;
		break;
	case 2:
		cout << "\n2. Xuat cay BTS";
		cout << "\t\t\t DANH SACH HOC VIEN";
		TieuDe();
		PreOrder(root);
		cout << "\n:";
		for (int i = 1; i <= MAXCOT; i++)
			cout << "=";
		cout << ":";
		cout << endl;
		cout << "So hoc vien co trong danh sach la: " << DemSoNut(root) << " hocvien";
		break;
	case 3:
		cout << "\n3. Xuat so nut cua cay (so luong hoc vien trong danh sach)\n";
		cout << "\t\t\t DANH SACH HOC VIEN";
		cout << endl;
		cout << "\nCay nhi phan co " << DemSoNut(root) << " nut";
		TieuDe();
		PreOrder(root);
		cout << "\n:";
		for (int i = 1; i <= MAXCOT; i++)
			cout << "=";
		cout << ":";
		cout << endl;
		cout << "So hoc vien co trong danh sach la: " << DemSoNut(root) << " hocvien";
		break;
	case 4:
		cout << "\n4. Xuat so nut la cua cay va thong tin tuong ung cua cac nut\n";
		cout << endl;
		TieuDe();
		kq = DemNutLa(root);
		cout << "\n:";
		for (int i = 1; i <= MAXCOT; i++)
			cout << "=";
		cout << ":";
		cout << "\nCay nhi phan co " << kq << " nut la";
		cout << "\n\nCay BST xuat theo thu tu cuoi (LRN) :\n";
		TieuDe();
		PosOrder(root);
		cout << "\n:";
		for (int i = 1; i <= MAXCOT; i++)
			cout << "=";
		cout << ":";
		break;
	case 5:
		cout << "\n5. Chieu cao cua cay\n";
		cout << "\nCay BT xuat theo thu tu cuoi (LRN) :\n";
		TieuDe();
		PosOrder(root);
		cout << "\n:";
		for (int i = 1; i <= MAXCOT; i++)
			cout << "=";
		cout << ":";
		cout << "\nCay nhi phan co " << DemSoNut(root) << " nut ";
		cout << "\nChieu cao cua cay : " << TinhChieuCao(root);
		break;
	case 6:
		cout << "\n6. Muc cua nut\n";

		break;
	case 7:
	{
		cout << endl << "\t\t\tDANH SACH HOC VIEN";
		TieuDe();
		PreOrder(root);
		cout << endl << "Nhap ma hoc vien can tim kiem: ";
		cin >> z;
		BSNode* p = Search(root, z);
		if (p != NULL)
		{
			cout << endl << "Tim thay hoc vien co ma hoc vien: " << z << " trong cay";
			cout << endl << "Thong tin cua hoc vien: " << z << " la: " << endl;
			TieuDe();
			Xuat_HV(p->info);
		}
		else
			cout << endl << "Khong tim thay ma hoc vien: " << z << ", vui long kiem tra lai!";
		break;
	}
	case 8:
		cout << "\n8. Xoa hoc vien co ma HV cho truoc\n";

		break;
	}
	cout << "\nPress any key to coutinue . . .";
	_getch();
}