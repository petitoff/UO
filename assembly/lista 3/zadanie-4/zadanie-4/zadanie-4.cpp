
#include "stdafx.h"

char napis[] = "To zdanie zostanie odwrocone";
char wynik[] = "";

int main()
{
	__asm
	{
		mov EDX, offset napis
		mov EBX, offset wynik

		naKoniec : mov AL, [EDX]

				   cmp AL, 0
				   jz koniec
				   inc EDX
				   jmp naKoniec
				   koniec :

	kopiowanie: dec EDX
		mov AL, [EDX]
		mov AH, AL
		cmp AH, 0
		jz koniecProgramu

		mov[EBX], AL
		inc EBX
		jmp kopiowanie
		koniecProgramu :
	}
	std::cout << wynik;
	std::cin.get();
}
