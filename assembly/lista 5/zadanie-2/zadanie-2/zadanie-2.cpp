#include "stdafx.h"

double liczba = 1.005;
double wynik;

int main()
{
	__asm
	{
		movzx EAX, liczba


	}
	std::cout << wynik;
	std::cin.get();
}
