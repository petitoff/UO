
#include "stdafx.h"

__int8 t[4] = { 1,2,3,4 };
short int d = 11;

int main()
{
	__asm
	{
		mov cx, d
		mov bx, cx
		and cx, 1
		xor cx, 1

		mov ax, bx
		mul cx
		add t[3], al

		xor cx, 1
		mov ax, bx
		mul cx
		add t[0], al
	}
	std::cout << "Zawartosc tablicy: " << (int)t[0] << ", " << (int)t[1] << ", " << (int)t[2] << ", " << (int)t[3] << std::endl;
	std::cin.get();
}
