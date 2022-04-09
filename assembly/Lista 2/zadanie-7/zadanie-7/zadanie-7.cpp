
#include "stdafx.h"

__int16 podzielnosc;
__int16 liczba = 16;

int main()
{
	__asm
	{
		mov AX, liczba
		and AX, 15
		mov BX, 16
		sub BX, AX
		shr BX, 4
		mov podzielnosc, BX
	}
	std::cout << podzielnosc;
	std::cin.get();
}
