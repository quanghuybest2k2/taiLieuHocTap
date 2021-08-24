
#include "BST.h"
// Sửa đổi tín chỉ
void SuaDoiTinChi(BSTree root,KeyType maHV, int soTin)
{
	if (root != NULL)
	{
		if (_strcmpi(root->info.maHocVien, maHV) == 0)
			root->info.soTin = soTin;
		if (_strcmpi(root->info.maHocVien, maHV) < 0)
			return SuaDoiTinChi(root->pRight, maHV, soTin);
		else
			return SuaDoiTinChi(root->pLeft, maHV, soTin);
	}
}

// Tìm node thế mạng (Node trái nhất của cây con phải)
void SearchStandFor(BSTree& p, BSTree& q)
{
	if (q->pLeft != NULL) // Node bên trái còn phần tử
		SearchStandFor(p, q->pLeft); // Duyệt để tìm Node trái nhất của cây con phải
	else
	{
		p->info = q->info;
		p = q;
		q = q->pRight;
	}
}

// Xóa
int DelNode(BSTree& root, KeyType maHV)
{
	if (root != NULL)
	{
		// Duyệt
		if (_strcmpi(root->info.maHocVien, maHV) < 0)
			return DelNode(root->pRight, maHV);
		if (_strcmpi(root->info.maHocVien, maHV) > 0)
			return DelNode(root->pLeft, maHV);
		else // Tìm thấy Node cần xóa rồi!
		{
			BSNode* p = root; // Node temp để tý nữa xóa
			// TH: Node có 1 con
			if (root->pLeft == NULL) 
				root = root->pRight;
			else if (root->pRight == NULL)
				root = root->pLeft;
			else // TH: Node có 2 con
				SearchStandFor(p, root->pRight); // Tìm node thế mạng (Node trái nhất của cây con phải)
			delete p;
			return 1;
		}
	}
	return 0;
}

// Tìm kiếm
void LayDanhSachLopCTK36(BSTree root)
{
	if (root != NULL)
	{
		if (_strcmpi(root->info.lop, "CTK36") == 0)
			Xuat1HocVien(root->info);
		LayDanhSachLopCTK36(root->pLeft);
		LayDanhSachLopCTK36(root->pRight);
	}
}

BSNode* Search(BSTree root, KeyType maHV)
{
	if (root != NULL)
	{
		if (_strcmpi(root->info.maHocVien, maHV) == 0) return root; // Tìm thấy!
		if (_strcmpi(root->info.maHocVien, maHV) < 0)
			return Search(root->pRight, maHV);
		else
			return Search(root->pLeft, maHV);
	}
	return NULL;
}