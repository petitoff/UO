
#include "stdafx.h"

__int16 tablica[3] = {5,7,9};
__int16 wynik;

int main()
{
	__asm
	{
		// Zadanie 4b

		xor ax,ax

		add AX, tablica[0]
		add AX, tablica[2]
		add AX, tablica[4]

		mov wynik, ax
	}
	std::cout << (int)wynik;
	std::cin.get();
}