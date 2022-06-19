#include "stdafx.h"
#include <random>


int main()
{
	std::random_device dev;
	std::mt19937 rng(dev());
	std::uniform_int_distribution<std::mt19937::result_type> dist6(0,1);

	std::cout << dist6(rng) << std::endl;
	std::cin.get();
}
