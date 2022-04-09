
#include "stdafx.h"

char napis[] = "ABCD";

int main()
{
	__asm
	{
		mov EDI, offset napis

		add[EDI], 32

		inc EDI

		add[EDI], 32

		inc EDI

		add[EDI], 32

		inc EDI

		add[EDI], 32
	}
	std::cout << napis;
	std::cin.get();
}
