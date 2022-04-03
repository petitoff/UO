
#include "stdafx.h"
char napis1[] = "abcd";
char napis2[] = "hjkl";

int main()
{
	__asm
	{
		mov EAX, offset napis1
		mov EBX, offset napis2

		start : MOV DL, [EAX]

				cmp DL, 0
				jz end
				XCHG DL, [EBX]
				MOV[EAX], DL

				inc EAX
				inc EBX

				jmp start
				end :
	}

	std::cout << napis1 << std::endl;
	std::cout << napis2;
	std::cin.get();
}
