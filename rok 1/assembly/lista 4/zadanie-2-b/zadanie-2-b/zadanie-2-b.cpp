﻿
#include "stdafx.h"

__int16 a = 3;
__int16 b = 5;

__int16 c = 4;
__int16 d = 6;

__int16 licznik;
__int16 mianownik;

int main()
{
	__asm
	{
		// mnożenie

		xor EAX, EAX
		xor EDX, EDX
		xor ECX, ECX

		mov AX, a
		mov CX, c
		mul CX

		mov licznik, AX

		mov AX, b
		mov CX, d
		mul CX

		mov mianownik, AX
	}

	std::cout << "licznik: " << licznik << std::endl;
	std::cout << "mianownik: " << mianownik;
	std::cin.get();
}
