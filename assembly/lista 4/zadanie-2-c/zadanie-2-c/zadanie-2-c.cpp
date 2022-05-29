
#include "stdafx.h"

__int16 a = 1;
__int16 b = 6;

__int16 c = 2;
__int16 d = 6;

__int16 licznik;
__int16 mianownik;

int main()
{
	__asm
	{
		// dzielenie

		xor EAX, EAX
		xor EDX, EDX
		xor ECX, ECX

		// jeżeli c == 0 to zakończ program ponieważ 0 nie może być w mianowniku
		mov AX, c
		cmp AX, 0
		jz koniec

		mov AX, a
		mov CX, d
		mul CX

		mov licznik, AX
		
		mov AX, b
		mov CX, c
		mul CX

		mov mianownik, AX

		koniec :

	}

	std::cout << "licznik: " << licznik << std::endl;
	std::cout << "mianownik: " << mianownik;
	std::cin.get();
}
