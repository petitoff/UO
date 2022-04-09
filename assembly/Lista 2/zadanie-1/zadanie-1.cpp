
#include "stdafx.h"

char napis[] = "ABCD";

int main()
{
	__asm
	{
		mov EDI, offset napis

		mov BL, 32
		add[EDI], BL

		inc EDI

		mov BL, 32
		add[EDI], BL

		inc EDI

		mov BL, 32
		add[EDI], BL

		inc EDI

		mov BL, 32
		add[EDI], BL
	}
	std::cout << napis;
	std::cin.get();
}
