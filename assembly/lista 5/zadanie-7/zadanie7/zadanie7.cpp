#include "stdafx.h"

double tablica[16] = { 2, 1, 3, 4, 3 };

int i = 0;
int j = 0;
int n = 5;

int pomoc1 = 0;
double pomoc2 = 1;

int main()
{
	__asm
	{
		mov j, 1

		FLD pomoc2;

		FST tablica[0]
			petla2 :

		add j, 1
			mov EAX, j
			mov EBX, n
			sub EBX, i
			sub EBX, 1

			cmp EAX, EBX
			jz koniec2
			jmp petla2

			koniec2 :
	}
	std::cout << j << std::endl;
	std::cout << tablica << std::endl;
	std::cin.get();
}
