// zadanie-1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "stdafx.h"

char napis[] = "ABCD";

int main()
{
	__asm
	{
		mov EDI, offset napis

		petla_tutaj: mov BL, 32
		add[EDI], BL

		inc EDI
		mov BL, [EDI]
		cmp BL, 0
		jne petla_tutaj
	}
	std::cout << napis;
	std::cin.get();
}
