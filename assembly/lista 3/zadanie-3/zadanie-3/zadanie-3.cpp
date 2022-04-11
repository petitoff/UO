
#include "stdafx.h"

char napis[] = "ab.a . d.";
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
		sub AL, 46
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
