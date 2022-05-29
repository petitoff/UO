#include "stdafx.h"

const int n = 6;
int koniec;
int tablica[n] = { 1, 2, 3, 4, 5 };
int suma;

int main()
{
	__asm
	{

		mov EBX, 0
		xor EAX, EAX
		xor EDX, EDX

		mov EAX, n
		mov ECX, 4
		mul ECX
		add EAX, 4
		mov koniec, EAX

		p1 : xor EAX, EAX
			 xor EDX, EDX

			 mov EAX, tablica[EBX]
			 mov ECX, 5
			 div ECX

			 cmp EAX, 0
			 jne spr


			 mov ECX, suma
			 mov EAX, tablica[EBX]
			 add ECX, EAX
			 mov suma, ECX

			 spr :
		cmp EBX, koniec
			jz koniecP
			add EBX, 4
			jmp p1
			koniecP :
	}

	std::cout << suma;
	std::cin.get();
}
