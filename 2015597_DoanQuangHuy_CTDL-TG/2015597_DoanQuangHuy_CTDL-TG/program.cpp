#include<iostream>
#include<fstream>
#include<conio.h>
#include<iomanip>
#include<string.h>

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
	int menu, soMenu = 5, n = 0;
	HocVien a[MAX];
	do
	{
		system("cls");
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, a, n);
		system("pause");
	} while (menu > 0);
}