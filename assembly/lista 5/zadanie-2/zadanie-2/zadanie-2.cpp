#include "stdafx.h"

double liczba = 1.005;
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

		mov EAX, wynik
		

		mov wynik, EAX
	}
	std::cout << wynik;
	std::cin.get();
}
