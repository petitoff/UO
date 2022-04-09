
#include "stdafx.h"
char napis1[4] = "abc";
char napis2[4] = "hjk";

int main()
{
	__asm
	{
		mov EAX, offset napis1
		mov EBX, offset napis2

		MOV DL, [EAX]

		XCHG DL, [EBX]
		MOV[EAX], DL

		inc EAX
		inc EBX

		MOV DL, [EAX]

		XCHG DL, [EBX]
		MOV[EAX], DL

		inc EAX
		inc EBX

		MOV DL, [EAX]

		XCHG DL, [EBX]
		MOV[EAX], DL
	}

	std::cout << napis1 << std::endl;
	std::cout << napis2;
	std::cin.get();
}
