
#include "stdafx.h"

char tablica1[] = "123";
__int16 wynik;

int main()
{
	__asm
	{
		mov EBX, offset tablica1
		//mov EBX, offset wynik

		mov AX, WORD PTR[EBX]
		inc EBX
		add AX, WORD PTR[EBX]
		inc EBX
		add AX, WORD PTR[EBX]
		mov wynik, AX
	}
	std::cout << (int)wynik;
	std::cin.get();
}