
#include "stdafx.h"

//__int16 liczba = 0b1010101010101010;

char liczba[16] = "111010101010101";
//__int16 liczba;

char wynik;

int main()
{
	__asm
	{
		mov EBX, offset liczba
		mov CL, 0

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej1

		add CL, 1

		dalej1: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej2

		add CL, 1

		dalej2: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej3

		add CL, 1

		dalej3: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej4

		add CL, 1

		dalej4: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej5

		add CL, 1

		dalej5: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej6

		add CL, 1

		dalej6: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej7

		add CL, 1

		dalej7: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej8

		add CL, 1

		dalej8: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej9

		add CL, 1

		dalej9: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej10

		add CL, 1

		dalej10: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej11

		add CL, 1

		dalej11: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej12

		add CL, 1

		dalej12: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej13

		add CL, 1

		dalej13: inc EBX

		mov wynik, CL

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej14

		add CL, 1

		dalej14: inc EBX

		mov AL, [EBX]
		cmp AL, '0'
		jz dalej15

		add CL, 1

		dalej15: inc EBX
	}
	std::cout << liczba << std::endl;
	std::cout << (int)wynik;
	std::cin.get();
}