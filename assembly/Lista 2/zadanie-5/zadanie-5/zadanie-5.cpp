
#include "stdafx.h"

__int16 wynik;

int main()
{
	__asm
	{
		mov ax, 10110b
		shr ax, 1011b
		and ax, 1b
		mov [wynik], ax
	}
	std::cout << wynik;
	std::cin.get();
}