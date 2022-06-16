#include "stdafx.h"

__int8 wynik;

int main()
{
	__asm
	{
	RANDSTART:
		MOV AH, 00h

		INT 1AH; 

		MOV BH, 57
		MOV AH, DL
		CMP AH, BH
		JA RANDSTART;

		MOV BH, 49
		MOV AH, DL
		CMP AH, BH
		JB RANDSTART;



		mov ah, 2h
		int 21h

	}
	std::cout << wynik << std::endl;
	std::cin.get();
}
