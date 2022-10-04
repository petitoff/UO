
#include "stdafx.h"

unsigned short int liczba = 6507;
char reszta;
int main()
{
	__asm
	{
		mov AX, liczba
		and AX, 3
		mov reszta, AL
	}
	std::cout << (int)reszta;
	std::cin.get();
}
