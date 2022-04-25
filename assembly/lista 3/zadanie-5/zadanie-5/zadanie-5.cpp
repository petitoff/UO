
#include "stdafx.h"

char napis[8] = "4F";
__int32 tablica[4];


int main()
{
	__asm
	{
		//mov EDX, offset napis
		//mov EBX, offset tablica
		xor EAX, EAX
		mov AL, napis[0]
		push AL

		sub AL, 48
		cmp AL, 10
		jg dalej1
		mov tablica[0], EAX
		jmp koniec1
		dalej1: pop AL
			   mov tablica[0], EAX
		
			   koniec1:

		xor EAX, EAX
			mov AL, napis[1]
			push AL

			sub AL, 48
			cmp AL, 10
			jg dalej2
			mov tablica[4], EAX
			jmp koniec2
			dalej2 : pop AL
			mov tablica[4], EAX

			koniec2 :




	}
	std::cout << tablica[0] << tablica[1];
	std::cin.get();
}