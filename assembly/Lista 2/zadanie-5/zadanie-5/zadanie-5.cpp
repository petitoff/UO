
#include "stdafx.h"
#include <bitset>

__int16 wynik = 0b1010101010101010;

int main()
{
	__asm
	{
		/*mov ax, 10110b
		shr ax, 1011b
		and ax, 1b*/

		mov AX, wynik
		shr AX, 1b
		mov wynik, AX

		//mov [wynik], ax
	}
	std::cout << std::bitset<16>(wynik);
	std::cin.get();
}