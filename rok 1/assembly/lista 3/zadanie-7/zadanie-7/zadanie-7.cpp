
#include "stdafx.h"

char napis[14] = "to jest napis";
__int8 wynik = 0;

int main()
{
	__asm
	{
		mov EAX, offset napis

		petla : mov DL, [EAX]
		cmp DL, 0
		jz koniec

		add wynik, 1
		inc EAX
		jmp petla

		koniec :
	}
	std::cout << (int)wynik;
	std::cin.get();
}
