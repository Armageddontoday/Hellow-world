#define _CRT_SECURE_NO_WARNINGS
#define PI  3.1415926535897932384626433832795
#include <cstdio>
#include "math.h"
#include <iostream>
using namespace std;
double Function(double x, int i)
{
	return pow(-1, i)* pow(x, 3 * i + 1)*sin(i*(PI*(double)1) / 4) / ((2 * i + 1)*(2 * i - 1));
}
int main()
{	
	double rowSumm = 0;
	double currentResult = 0;
	double previousResult = 0;
	double x;
	int i;
	scanf("%lf", &x);
	for(i=1;;i++)
	{
		previousResult = currentResult;
		currentResult = Function(x, i);// pow(-1, i)* pow(x, 3 * i + 1)*sin(i*(PI*(double)1) / 4) / ((2 * i + 1)*(2 * i - 1));
		rowSumm += currentResult;
	//	printf("curr: %.18f  \n", currentResult);
	//	printf("prev: %.18f  \n", previousResult);
	//	printf("fabs: %.18f  \n", (fabs(currentResult - previousResult)));
		if (fabs(currentResult - previousResult)<1e-18) break;
	}	
	printf("summ: %.20f \n", rowSumm);
	return 0;
}