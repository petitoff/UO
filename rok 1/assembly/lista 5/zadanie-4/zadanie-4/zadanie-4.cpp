#include "stdafx.h"

double x = 3;
double y = 4;

double a = -2;
double b = 1;
double c = 5;

double licznik;
double mianownik;
double wynik;
int main()
{
	__asm
	{
		FLD a
		FMUL x

		FLD b
		FMUL y

		FADD ST(0), ST(1)
		FADD c

		FABS

		FST licznik

		FLD a
		FMUL a
		FST a

		FLD b
		FMUL b
		FST b

		FADD a
		FSQRT
		FST mianownik

		FLD licznik
		FDIV mianownik
		FST wynik;
	}
	std::cout << licznik << std::endl;
	std::cout << mianownik << std::endl;
	std::cout << wynik << std::endl;
	std::cin.get();
}
