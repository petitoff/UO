
#include "stdafx.h"

char napis[] = "abcz";

int main()
{
	__asm
	{
		mov EDI, offset napis

		petla_tutaj : mov BL, 1
					  add[EDI], BL

					  inc EDI
					  mov BL, [EDI]
					  cmp BL, 0
					  jne petla_tutaj
	}
	std::cout << napis;
	std::cin.get();
}
