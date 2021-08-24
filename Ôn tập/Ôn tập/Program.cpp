#include<iostream>
#include<conio.h>
#include<iomanip>
#include<fstream>
using namespace std;
#include"ThuVien.h"
#include"Menu.h"

void ChayChuongTrinh();

int main()
{
	ChayChuongTrinh();
	return 1;
}

void ChayChuongTrinh()
{
	BSTree root;
	int menu, soMenu = 8;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, root);
	} while (menu > 0);
}