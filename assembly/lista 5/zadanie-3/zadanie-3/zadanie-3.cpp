#include "stdafx.h"

double a = 1;
double b = 2;
double c = -3;

double liczba1 = -4;
double liczba2 = 0;
double liczba3 = -1;
double liczba4 = 2;
double delta;

double wynik;
__int16 wynik2;

double x1 = 0;
double x2 = 0;

int main()
{
	__asm
	{
		// kwadrat z liczby
		FLD b
		FMUL b

		FLD a
		FMUL c
		FMUL liczba1

		FADD ST(0), ST(1)

		// FTST
		// FST wynik

		// fstsw ax
		// jz   st0_zero
		// mov wynik2, AX

		ftst
		fstsw ax
		fwait
		sahf

		ja   st0_positive; // when all flags are 0
		jb   st0_negative; // only the C0 bit(CF flag) would be set if no error
		jz   st0_zero; // only the C3 bit(ZF flag) would be set if no error

		jmp end // przechwytywanie wyjątku jeżeli cos się nie powiedzie
			st0_positive : mov wynik2, 1 // jeżeli delta > 0
			FSQRT // pierwiastek z ST(0)
			FST delta

			FLD b
			FMUL liczba3
			FST b

			FLD a
			FMUL liczba4
			FST a

			FLD b
			FADD delta
			FDIV a

			FST x1 // wynik x1

			FLD b
			FSUB delta
			FDIV a

			FST x2 // wynik x2
			jmp end

			st0_negative : mov wynik2, 2 // jeżeli delta < 0
			jmp end

			st0_zero : mov wynik2, 3 // jeżeli delta równa 0
			FSQRT // pierwiastek z ST(0)
			FST delta

			FLD a
			FMUL liczba4
			FST a

			FLD b
			FMUL liczba3
			FDIV a

			FST x1
			FST x2
			jmp end

			end :
	}
	// jeżeli delta jest równa 0 to wyniki x1 i x2 przyjmują te same wartości
	// jeżeli delta jest mniejsza od 0 to x1 i x2 są zerami
	std::cout << x1 << std::endl;
	std::cout << x2 << std::endl;
	std::cin.get();
}
