
#include "stdafx.h"

char tablica1[] = "123";
__int8 wynik;

int main()
{
	__asm
	{
		mov EBX, offset tablica1
		//mov EBX, offset wynik

		mov AL, [EBX]
		inc EBX
		add AL, [EBX]
		inc EBX
		add AL, [EBX]
		mov wynik, AL
	}
	std::cout << (int)wynik;
	std::cin.get();
}