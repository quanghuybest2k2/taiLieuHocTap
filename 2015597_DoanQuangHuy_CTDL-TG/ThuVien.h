#define MAX 100
#define NGANGDOI '='
#define NGANGDON '-'


struct HocVien
{
	char maHV[8];
	char hoHV[7];
	char tenDem[7];
	char ten[7];
	char lop[7];
	int namSinh;
	double diem;
	int soTC;
};

int Chuyen_TT_BD(char* filename, HocVien a[MAX], int& n);
void XuatKeNgangDoi();
void XuatKeNgangDon();
void XuatTieuDe();
void Xuat(HocVien a[MAX], int n);
void XuatBD(HocVien a[MAX], int n);

int Chuyen_TT_BD(char* filename, HocVien a[MAX], int& n)
{
	ifstream in(filename);
	if (!in)
		return 0;
	n = 0;
	while (!in.eof())
	{
		in >> a[n].maHV;
		in >> a[n].hoHV;
		in >> a[n].tenDem;
		in >> a[n].ten;
		in >> a[n].lop;
		in >> a[n].namSinh;
		in >> a[n].diem;
		in >> a[n].soTC;
		n++;
	}
	in.close();
	return 1;
}

void XuatKeNgangDoi()
{
	cout << setiosflags(ios::left) << '|';
	for (int i = 0; i < 92; i++)
	{
		cout << '=';
	}
	cout << '|';
}

void XuatKeNgangDon()
{
	cout << setiosflags(ios::left) << '|';
	for (int i = 0; i < 92; i++)
	{
		cout << '-';
	}
	cout << '|';
}

void XuatTieuDe()
{
	XuatKeNgangDoi();
	cout << "\n" << setiosflags(ios::left) << '|'
		<< setw(8) << "Ma HV" << '|'
		<< setw(7) << "HO" << '|'
		<< setw(7) << "TEN DEM" << '|'
		<< setw(7) << "TEN" << '|'
		<< setw(7) << "LOP" << '|'
		<< setw(8) << "NAM SINH" << '|'
		<< setw(7) << "Diem" << '|'
		<< setw(7) << "SO TC" << '|' << "\n";
	XuatKeNgangDoi();
}

void Xuat_1_HV(HocVien a)
{
	cout << "\n" << setiosflags(ios::left) << '|'
		<< setw(8) << a.maHV << '|'
		<< setw(7) << a.hoHV << '|'
		<< setw(7) << a.tenDem << '|'
		<< setw(7) << a.ten << '|'
		<< setw(7) << a.lop << '|'
		<< setw(8) << a.namSinh << '|'
		<< setw(7) << a.diem << '|'
		<< setw(7) << a.soTC << '|' << "\n";
	XuatKeNgangDon();
}

void XuatBD(HocVien a[MAX], int n)
{
	XuatTieuDe();
	for (int i = 0; i < n; i++)
	{
		Xuat_1_HV(a[i]);
	}
}

void Xuat(HocVien a[MAX], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << setw(8) << a[i].maHV
			<< setw(7) << a[i].hoHV
			<< setw(7) << a[i].tenDem
			<< setw(7) << a[i].ten
			<< setw(7) << a[i].lop
			<< setw(8) << a[i].namSinh
			<< setw(7) << a[i].diem
			<< setiosflags(ios::fixed) << setprecision(2) << setw(10) << a[i].soTC;
		cout << endl;
	}
}
