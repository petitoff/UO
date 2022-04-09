
#include "stdafx.h"

__int16 t[4] = { 1,2,3,4 };
__int8 d = 12;

int main()
{
	__asm
	{
		mov CL, d
		mov BL, CL
		and CL, 1
		xor CL, 1

		mov AL, BL
		mul CL
		add t[6], AX

		xor CL, 1
		mov AL, BL
		mul CL
		add t[0], AX
	}
	std::cout << "Zawartosc tablicy: " << (int)t[0] << ", " << (int)t[1] << ", " << (int)t[2] << ", " << (int)t[3] << std::endl;
	std::cin.get();
}
