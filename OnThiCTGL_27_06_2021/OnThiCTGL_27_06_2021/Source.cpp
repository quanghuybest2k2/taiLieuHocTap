#include "Menu.h"
void ChayChuongTrinh();

int main()
{
	ChayChuongTrinh();
	return 1;
}

void ChayChuongTrinh()
{
	int stt, soMenu = 6;
	BSTree root = NULL;
	do
	{
		stt = ChonMenu(soMenu);
		XuLyMenu(root, stt);
	} while (true);
}