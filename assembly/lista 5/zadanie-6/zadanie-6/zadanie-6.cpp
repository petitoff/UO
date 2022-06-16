#include "stdafx.h"

int const wielkosc = 4;
double tablica[wielkosc] = { 7,4,-2 };

double liczba0 = 0;
double liczbam1 = -1;
double liczba2;

int pomoc1; // przechowuje wielkosc tablicy
int pomoc2 = 0; // aktualny index w tablicy
double pomoc3 = 1;
int pomoc4;
double pomoc5;

double wynik1;
double wynik2;
int main()
{
	__asm
	{
		// liczymy srednia arytmetyczna

		mov EBX, wielkosc
		mov pomoc1, EBX
		FLD liczba0;

	petla1:
		mov EBX, pomoc2
			FADD tablica[EBX]
			add EBX, 8
			mov pomoc2, EBX
			mov EBX, pomoc1
			sub EBX, 1

			cmp EBX, 0
			jz dalej1

			mov pomoc1, EBX

			jmp petla1

			dalej1 :

		mov EAX, wielkosc
			mov pomoc4, EAX

			FBLD pomoc4
			FSUB pomoc3

			FDIV ST(1), ST(0)

			// FDIVR pomoc1
			FXCH ST(1)
			FST wynik1; // zapisanie średniej arytmetycznej

			// obliczamy odchylenie standardowe
		mov EBX, wielkosc
			mov pomoc1, EBX
			FLD liczba0;
			mov EBX, 0
			mov pomoc2,EBX

	petla2:
		mov EBX, pomoc2
			FLD tablica[EBX]
			add EBX, 8
			mov pomoc2, EBX
			mov EBX, pomoc1
			sub EBX, 1

			FSUB wynik1
			FMUL ST(0), ST(0)
			FADD pomoc5
			FST pomoc5

			cmp EBX, 1
			jz dalej2
			mov pomoc1, EBX
			jmp petla2

			dalej2 :
			FDIV wynik1
			FSQRT
			FST wynik2;
	}
	// std::cout << wynik1 << std::endl; // średnia arytmetyczna
	std::cout << wynik2 << std::endl; // wynik
	std::cin.get();
}
