#include "stdafx.h"

double tablica[16] = { 15,14,13,12,11,10,9,8,7,6,5,4,3,2,1 };

int i = 0; // iterator pętli zewnętrznej
int j = 1; // iterator pętli wewnętrznej
int n = 14; // ilość elementów w pętli
int m = 1;

int indexPierwszy = 0;
int indexDrugi = 8;


// using namespace std;

int main()
{
	__asm
	{
		petla2:
	petla1: mov ECX, indexPierwszy
			mov EBX, indexDrugi
			xor EAX, EAX

			FLD tablica[ECX]
			FLD tablica[EBX]

			FSUB ST(1), ST(0)
			FXCH ST(1)

			ftst // przyrównujemy do zera
			fstsw ax
			fwait
			sahf

			ja   st0_positive; // jeżeli wynik większy od 0
			jb   st0_negative; // only the C0 bit(CF flag) would be set if no error
			jz   st0_zero; // only the C3 bit(ZF flag) would be set if no error
			jmp dalej1

				st0_positive :
				FLD tablica[ECX]
				FLD tablica[EBX]

				FSTP tablica[ECX]
				FSTP tablica[EBX]

				st0_negative:
				st0_zero:
				dalej1 :

				add indexPierwszy, 8
				add indexDrugi, 8
				add j, 1

				mov EAX, n
				cmp j, EAX
				jz endA

				jmp petla1

					endA :
				mov indexPierwszy, 0
				mov indexDrugi, 8
				mov j, 1

				add i, 1
				mov EAX, m
				cmp i, EAX
				jz endEnd
				jmp petla2

				endEnd:

			//FST tablica[0]
	}
	//std::cout << j << std::endl;
	// std::cout << tablica[0] << std::endl;
	//std::cout << std::endl;

	std::cout << tablica[0] << std::endl;
	std::cout << tablica[1] << std::endl;
	std::cout << tablica[2] << std::endl;
	std::cout << tablica[3] << std::endl;
	std::cout << tablica[4] << std::endl;
	std::cout << tablica[5] << std::endl;
	std::cout << tablica[6] << std::endl;
	std::cout << tablica[7] << std::endl;
	std::cout << tablica[8] << std::endl;
	std::cout << tablica[9] << std::endl;
	std::cout << tablica[10] << std::endl;
	std::cout << tablica[11] << std::endl;
	std::cout << tablica[12] << std::endl;
	std::cout << tablica[13] << std::endl;
	std::cout << tablica[14] << std::endl;
	std::cout << tablica[15] << std::endl;

	// wyświetlanie elementów z tablicy
	//for (int i = 0; i < sizeof(tablica); i++)
	//{
	//	std::cout << tablica[i] << std::endl;
	//}

	std::cin.get();
}
