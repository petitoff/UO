
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

		mov ebx, eax

		mul eax
		mul eax
		mul eax
		mul ebx

		mov wynik, eax
	}
	std::cout << wynik;
	std::cin.get();
}
