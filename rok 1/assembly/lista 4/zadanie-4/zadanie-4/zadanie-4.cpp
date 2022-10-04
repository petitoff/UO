
#include "stdafx.h"

int szukanaLiczba = 12;
int x;
int y;
int z;

int main()
{
	__asm
	{
		mov y, 1;
		mov BL, 0

			p1: xor EDX, EDX
			xor EAX, EAX

			mov EAX, x
			mul EAX
			push EAX

			mov EAX, y
			mul EAX

			mov ECX, EAX
			pop EAX

			add EAX, ECX
			mov z, EAX

			mov EAX, x
			mov ECX, y
			add EAX, ECX
			mov ECX, z
			add EAX, ECX



			cmp EAX, szukanaLiczba
			jz kp1

			cmp BL, 1 // jeżeli BL 1 to odejmij 1 od y i odejmij od BL 1
			jz odejmij
			// jeżeli BL 0 to dodaj 1 do x
			mov EAX, x
			add EAX, 1
			mov x, EAX

			add BL, 1
			jmp p1

			odejmij :
		sub BL, 1

			mov EAX, y
			add EAX, 1
			mov y, EAX

			jmp p1

			kp1 :

	}
	std::cout << "x: " << x << std::endl;
	std::cout << "y: " << y << std::endl;
	std::cout << "z: " << z << std::endl;
	std::cin.get();
}
