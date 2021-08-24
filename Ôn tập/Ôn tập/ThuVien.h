#define MAXCOT 73

typedef char KeyType[8];
// kiểu dữ liệu của các nút (int)
//typedef int HocVien;
struct HocVien
{
	//char maHV[8];
	KeyType maHV;
	char hoHV[10];
	char tenLot[10];
	char ten[10];
	char lop[6];
	int namSinh;
	double dtb;
	int tichLuy;
};

// Kiểu các nút của cây
struct BSNode
{
	HocVien info;
	BSNode* left; // chứa địa chỉ cây con trái
	BSNode* right;// chứa địa chỉ cây con phải
};

//Kieu CTDL Cay nhi phan tim kiem:
//kieu con tro tro den cac nut kieu BSNode
typedef BSNode* BSTree;
//1. Tạo nút với key x cho trước : CreateNode
//Input x : HocVien.txt
//Output : NULL ; khong thanh cong (rỗng)
// p; tro den nut vua tao, neu thanh cong
//khai bao nguyen ham

BSNode* CreateNode(HocVien x) // GetNode : tao nut
{
	BSNode* p = new BSNode;
	if (p != NULL)
	{
		p->info = x;
		p->left = NULL;
		p->right = NULL;
	}
	return p;
}
//2. Tạo cây BST rổng(khởi tạo)
//Cho con trỏ quản lý địa chỉ nút gốc có giá trị NULL
//Input : root
//Output : root
void CreateBST(BSTree& root)
{
	root = NULL;
}
// them x vao cay BST
int insertNode(BSTree& root, HocVien x)
{
	if (root != NULL) // Cat khac rong
	{
		if (_strcmpi(root->info.maHV, x.maHV) == 0)
			return 0;
		if (_strcmpi(root->info.maHV, x.maHV) < 0)
			return insertNode(root->right, x);
		else
			return insertNode(root->left, x);
		/*return insertNode(root->left, x);
		return insertNode(root->right, x);*/
	}//root == NULL
	root = CreateNode(x);
	if (root == NULL)
	{
		return -1;  // Không đủ bộ nhớ
	}
	return 1; // successfull!
}
//Dem so nut : So luong hoc vien trong danh sach
int DemSoNut(BSTree root)
{
	if (root == NULL)
		return 0;
	return 1 + DemSoNut(root->left) + DemSoNut(root->right);
}
int File_BST(BSTree& root, char* filename)
{
	ifstream in(filename);
	if (!in)
		return 0;
	KeyType maHV;
	int kq;
	CreateBST(root);
	HocVien x;
	while (!in.eof())
	{
		in >> x.maHV;
		in >> x.hoHV;
		in >> x.tenLot;
		in >> x.ten;
		in >> x.lop;
		in >> x.namSinh;
		in >> x.dtb;
		in >> x.tichLuy;
		kq = insertNode(root, x);
		if (kq == 0 || kq == -1)
			return 0;
	}
	in.close();
	return 1;
}
void TieuDe()
{
	int i;
	cout << endl;
	cout << ":";
	for (i = 1; i <= MAXCOT; i++)
		cout << "=";
	cout << ":";
	cout << endl;
	cout << setiosflags(ios::left);
	cout << ':'
		<< setw(8) << "maHV"
		<< ':'
		<< setw(10) << "Ho"
		<< setw(10) << "Tenlot"
		<< setw(10) << "Ten"
		<< ':'
		<< setw(8) << "Lop"
		<< ':'
		<< setw(6) << "NS"
		<< ':'
		<< setw(6) << "DTB"
		<< ':'
		<< setw(10) << "TichLuy"
		<< ':';
	cout << "\n";
	cout << ":";
	for (i = 1; i <= MAXCOT; i++)
		cout << "=";
	cout << ":";
}
//Xuat 1 hoc vien
void Xuat_HV(HocVien p)
{
	cout << endl;
	cout << setiosflags(ios::left)
		<< ':'
		<< setw(8) << p.maHV
		<< ':'
		<< setw(10) << p.hoHV
		<< setw(10) << p.tenLot
		<< setw(10) << p.ten
		<< ':'
		<< setw(8) << p.lop
		<< ':'
		<< setw(6) << p.namSinh
		<< ':'
		<< setw(6) << setprecision(2) << p.dtb << ':'
		<< setw(10) << p.tichLuy
		<< ':';
}
//Duyet va Xuat cay theo thu tu truoc : NLR
void PreOrder(BSTree root)
{
	if (root != NULL)
	{
		Xuat_HV(root->info);
		PreOrder(root->left);
		PreOrder(root->right);
	}
}
//----------------------------------
//Duyet va Xuat cay theo thu tu giua : LNR
void InOrder(BSTree root)
{
	if (root != NULL)
	{
		InOrder(root->left);
		Xuat_HV(root->info);
		InOrder(root->right);
	}
}
////----------------------------------
////Duyet va Xuat cay theo thu tu sau : LRN
void PosOrder(BSTree root)
{
	if (root != NULL)
	{
		PosOrder(root->left);
		PosOrder(root->right);
		Xuat_HV(root->info);
	}
}
//Dem so nut la
int DemNutLa(BSTree root)
{
	int soNutLa;
	if (root == NULL)
		soNutLa = 0;
	else
		if (root->left == NULL && root->right == NULL)
		{
			Xuat_HV(root->info);
			soNutLa = 1;
		}
		else
			soNutLa = DemNutLa(root->left) + DemNutLa(root->right);
	return soNutLa;
}
int TinhMax(int a, int b)
{
	if (a >= b)
		return a;
	return b;
}
//Chieu cao cua cay
int TinhChieuCao(BSTree root)
{
	int h;
	if (root == NULL)
		h = -1;
	else
		if (root->left == NULL && root->right == NULL)
			h = 0;
		else
			h = 1 + TinhMax(TinhChieuCao(root->left), TinhChieuCao(root->right));
	return h;
}
//Tim kiem hoc vien theo maHV :Preorder
//Voi p la bien toan cuc, tro den hoc vien tim duoc neu co
BSNode* Search(BSTree root, KeyType maHV)
{
	if (root != NULL)
	{
		if (_strcmpi(root->info.maHV, maHV) == 0) return root; // Tìm thấy!
		if (_strcmpi(root->info.maHV, maHV) < 0)
			return Search(root->right, maHV);
		else
			return Search(root->left, maHV);
	}
	return NULL;
}
//Xuat cac hoc vien co ten cho truoc :Preorder
//Voi dem la bien toan cuc
void Xuat_HV_Ten(BSTree root, char ten[8])
{
	int dem = 0;
	if (root != NULL)
	{
		if (_strcmpi(root->info.ten, ten) == 0)
		{
			dem++;
			Xuat_HV(root->info);
		}
		Xuat_HV_Ten(root->left, ten);
		Xuat_HV_Ten(root->right, ten);
	}
}