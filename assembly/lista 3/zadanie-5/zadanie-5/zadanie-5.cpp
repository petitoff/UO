
#include "stdafx.h"

char napis[9] = "61616161";
__int32 tablica[4] = {};


int main()
{
	__asm
	{
		mov EDX, offset napis
		//mov EBX, offset tablica
		xor EAX, EAX

		mov AL, [EDX]
		mov tablica[0], EAX
	}
	std::cout << tablica[0];
	std::cin.get();
}