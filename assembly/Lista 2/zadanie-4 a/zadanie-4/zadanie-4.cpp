
#include "stdafx.h"

char tablica[4] = { 1,2,3 };
char wynik[2];

int main()
{
	__asm
	{
		// Zadanie 4a
		mov AL, tablica[0]
		mov AH, tablica[1]
		mov BL, tablica[2]

		add AH, AL
		add AH, BL

		mov wynik[0], AH
	}
	std::cout << (int)wynik[0];
	std::cin.get();
}