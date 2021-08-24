#include <iostream>
#include <conio.h>
#include <fstream>
#include <iomanip>

using namespace std;

#include "2015597_BST.h"
#include "2015597_ThuVien.h"
#include "2015597_Menu.h"

void ChayChuongTrinh();

int main()
{
	ChayChuongTrinh();

	return 1;
}
void ChayChuongTrinh()
{
	int stt, soMenu = 5;
	BSTree root = NULL;
	do
	{
		stt = ChonMenu(soMenu);
		XuLyMenu(root, stt);
	} while (true);
}