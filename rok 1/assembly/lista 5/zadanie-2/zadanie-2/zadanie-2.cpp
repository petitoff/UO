#include "stdafx.h"

double liczba = 12.005;
double m = 1000;
int wynik;


int main()
{
	__asm
	{
		// movzx EAX, liczba
		FLD liczba;
		FMUL m;

		FIST wynik;

		xor EAX, EAX
			xor EBX, EBX

			xor EDX, EDX
			xor EAX, EAX

			mov EAX, wynik

			petla : mov ECX, 5
			sub EAX, ECX
			cmp EAX, 0
			jz koniec
			jb koniec2
			jmp petla

			koniec :
		mov wynik, EAX
			jmp end

			koniec2 :
		mov wynik, -1

			end:
	}
	// jeżeli wynik to 0 to liczba miała na 3 miejcu 5
	// jeżeli wynik to -1 to liczba nie miała na 3 miejscu 5
	std::cout << wynik;
	std::cin.get();
}
