
#include "stdafx.h"

char napis[] = "Zdanie. Kolejne! Nastepne?";
__int8 wynik = 0;
int main()
{
	__asm
	{
		mov EDX, offset napis

		dalej: mov AL, [EDX]

		cmp AL, 0
		jz koniec
		inc EDX

		mov AH, AL
		sub AL, 46
		cmp AL, 0
		jz dodaj

		mov Al, AH
		sub AL, 33
		cmp AL, 0
		jz dodaj

		mov Al, AH
		sub AL, 63
		cmp AL, 0
		jz dodaj

		jmp dalej
		dodaj: add wynik,1
			   jmp dalej
		koniec:
	}
	std::cout << (int)wynik;
	std::cin.get();
}
