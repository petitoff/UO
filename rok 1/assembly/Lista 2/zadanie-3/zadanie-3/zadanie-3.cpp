
#include "stdafx.h"

char napis1[4] = "asd";
char napis2[4] = "fgh";
char napis3[7] = "";

int main()
{
	__asm
	{
		mov AL, napis1[0]
		mov AH, napis2[0]
		mov napis3[0], AL
		mov napis3[1], AH

		mov AL, napis1[1]
		mov AH, napis2[1]
		mov napis3[2], AL
		mov napis3[3], AH

		mov AL, napis1[2]
		mov AH, napis2[2]
		mov napis3[4], AL
		mov napis3[5], AH
	}
	std::cout << napis3;

	std::cin.get();
}
