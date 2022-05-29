
#include "stdafx.h"

int liczby[7] = { 1,2,3,4,5,6 };
int pomoc;
double d = 6;
double wynik;

int main()
{
	__asm
	{
		mov CL, 0

		p1: mov EAX, liczby[ECX]
			push EAX

			add CL, 4
			cmp CL, 24
			jz kp1
			jmp p1


			kp1 : xor EAX, EAX
				  xor EDX, EDX
				  xor EDX, EDX

				  pop EAX
				  mov BL, 5

				  p2 : pop ECX
					   add EAX, ECX

					   sub BL, 1
					   cmp BL, 0
					   jz kp2
					   jmp p2
					   kp2 : push EAX

							 xor EAX, EAX
							 xor EDX, EDX
							 xor EDX, EDX

							 pop EAX

							 mov pomoc, EAX

							 FILD pomoc

							 FDIV d
							 FSTP wynik


	}
	std::cout << wynik;
	std::cin.get();
}
