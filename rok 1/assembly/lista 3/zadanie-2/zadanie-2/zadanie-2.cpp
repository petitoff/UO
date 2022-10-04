
#include "stdafx.h"

__int16 pierwiastek = 4;
__int32 wynik;
int main()
{
	__asm
	{
		mov BX, 1

		dalej:mov  AX, BX
			  mov  CX, BX
			  mul  CX // ax = ax * cx

			  sub AX, pierwiastek

			  cmp AX, 0
			  jz koniec

			  add BX, 1
			  jmp dalej

			  koniec : mov pierwiastek, BX
	}
	std::cout << pierwiastek;
	std::cin.get();
}
