
#include "stdafx.h"

char napis[] = "abcz";
__int8 index = 0;

int main()
{
	__asm
	{
		mov EDI, offset napis
		mov AL, 1
		petla_tutaj:	mov BL, AL // o ile ma nastąpić przesunięcie znaku

						add AL, 1
						add[EDI], BL // przesunięcie znaku

						inc EDI // zwiększenie wskaźnika o 1
						mov BL, [EDI] // przeniesienie bajtu do rejestru BL
						cmp BL, 0 // sprawdzenie czy jest zerem aby sprawdzić czy to nie koniec string'u
						jne petla_tutaj // jeżeli nie to wykonuj od początku
	}
	std::cout << napis;
	std::cin.get();
}
