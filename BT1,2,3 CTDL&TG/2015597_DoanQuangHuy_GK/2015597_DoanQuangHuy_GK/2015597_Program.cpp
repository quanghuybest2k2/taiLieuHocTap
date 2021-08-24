#include <iostream>
#include <fstream>
#include <iomanip>
#include <conio.h>

using namespace std;

#include "2015597_ThuVien.h"
#include "2015597_Menu.h"

void ChayChuongTrinh()
{
	LIST l;
	int menu, soMenu = 5;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, l);
	} while (menu > 0);
}

int main()
{
	ChayChuongTrinh();
	return 1;
}