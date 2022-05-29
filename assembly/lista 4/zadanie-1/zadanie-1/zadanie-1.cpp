#include "stdafx.h"

__int16 liczba1 = 24;
__int16 liczba2 = 36;

__int16 copyLiczba1;
__int16 copyLiczba2;

__int16 wynik;
__int16 pom;

int main()
{

	__asm
	{
		mov AX, liczba1
		mov copyLiczba1, AX

		mov AX, liczba2
		mov copyLiczba2, AX



		xor EAX, EAX
		xor EDX, EDX

		p1 :
		mov AX, copyLiczba2 // przenieś druga liczbe do AX
			mov pom, AX // przenieś liczbę z ax do pom

			// zerowanie rejestrów
			xor EAX, EAX
			xor EDX, EDX

			// dzielenie rejestrów AX, CX
			mov AX, copyLiczba1
			mov CX, copyLiczba2
			div CX

			// mnożenie rejestrów AX, CX
			xor EDX, EDX
			mov CX, copyLiczba2
			mul CX

			// odejmowani rejestrów AX, CX
			mov CX, AX
			mov AX, copyLiczba1
			sub AX, CX

			mov copyLiczba2, AX
			mov AX, pom
			mov copyLiczba1, AX

			cmp copyLiczba2, 0
			jz kp1
			jmp p1
			kp1 :

		// wykorzystujemy wzór (a/nwd) * b
		// a = liczba1
		// b = liczba2
		// nwd = copyLiczba1

		mov AX, liczba1
			mov CX, copyLiczba1
			div CX // dokunujemy dzielenia AX, CX

			mov CX, liczba2
			mul CX // mnożenie AX, CX (w AX jest wynik dzielenia)

			mov wynik, AX // przesyłamy wnik z AX do zmiennej wynik
	}
	std::cout << wynik;
	std::cin.get();
}
