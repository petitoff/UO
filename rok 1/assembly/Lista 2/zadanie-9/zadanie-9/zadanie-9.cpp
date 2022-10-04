
#include "stdafx.h"

__int8 liczba = 20;
int wynik;

int main()
{
	__asm
	{
		xor EAX, EAX
		mov AL, liczba
		and EAX, 7

		mov EBX, EAX

		mul EAX
		mul EAX
		mul EAX
		mul EBX

		mov wynik, EAX
	}
	std::cout << wynik;
	std::cin.get();
}
