
#include "stdafx.h"

char napis1[] = "asd";
char napis2[] = "fgh";
char napis3[] = "";

int main()
{
	__asm
	{
		mov EAX, offset napis3
		mov EBX, offset napis1
		mov ECX, offset napis2

		start : mov DL, [EBX]
				cmp DL, 0
				jz end
				mov[EAX], DL
				inc EAX	

				mov DL, [ECX]
				mov[EAX], DL

				inc EBX
				inc ECX
				inc EAX
				jmp start
				end :
	}
	std::cout << napis3;

	std::cin.get();
}
