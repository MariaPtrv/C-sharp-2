//// ������ ��� ������������ ������ �� ���������� � ��������������� ����������
//#include <conio.h>
//#include <locale.h> // ��� �������� ������
//#include <signal.h>
//#include <windows.h> // for EXCEPTION_ACCESS_VIOLATION
//#include <excpt.h>
//#include <iostream>
//using namespace std;
//int iMas[10]; // �������� ���������� ������
//int i = 0;
//int* add;// �������� ��������������� ����������
//int doSmth(int param) {
//	return param *= param;
//}
//int main() {
//	int* dinamic = new int(10);
//	int iLMas[10]; // �������� ��������� ������
//	setlocale(LC_ALL, ".1251"); // ����� ���������� ��-������
//
//		// ���������� ��������� � ������ �� ������ �������
//		__try {
//			while (1) {
//			iMas[i] = i; /* ��������� � ������� ���������� ������ */cout << iMas[i] << endl; add = &iMas[i];
//			//iLMas[i] = i; /*��������� � ������� ��������� ������ */cout <<iLMas[i] << endl; add = &iLMas[i];
//			//cout << dinamic++ << endl; //��������� � ������, ��� ������� ������ �������� �����������
//			// add = reinterpret_cast<int*>(*doSmth); /*��������� � ������� ���� */ cout << add + i<< endl;
//			i++;
//
//			}
//		}
//
//		__catch (...) {
//			cout << "��������� ����������:" << endl;
//
//			cout << "��������� ���� ������� � ������, ������������� �� ������ " << hex << add + 4 << endl;
//			cout << "����� ����������� ������� iMas: " << iMas << endl;
//			//cout << "����� ���������� ������� iLMas: "<< iLMas << endl;
//			//cout << "��������� ����� ���������: " << address << endl;
//			cout << "������ ������� ������: " << dec << (add + 4 - iMas) * 4 / 8 << " ����" << endl;
//			//cout << "������ ������� ������: " << dec <<(x - address) * 4 / 8 << " ����" � endl;
//		}
//		
//
//	_getch();
//	return 0;
//}

#include <stdio.h>
#include <excpt.h>
#include <locale.h>
#define size 10
int iMas[size];
int i = 0;
int* ipMas;
int do_smth(int a) { 
	return a * a;
}
int main(void) {
	setlocale(LC_ALL, "rus");
	int iLMas[size]; 
	int* add = &iLMas[0];
	int (*temp)(int);
	int* x = new int(10);
	/*printf("���������� ������\n");
	i = 0;
		__try {
			while (1) { 
				add = &iMas[i];
				iMas[i] = i; 
				i++; 
			}
	}
		__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\n�������� ���������� �� ������\n %08x\n��� ���������� ����������: %08x\n���: %d\n������ ������� ������: %d ����\n", 
			(iMas[i] + i), GetExceptionCode(), i, (add + 4 - iMas) * 4 / 8);
	}*/
	printf("��������� ������\n");
	i = 0;
	__try {
		while (1) {
			add = &iLMas[i];
			printf("%d",iLMas[i]+i);
			i++;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\n�������� ���������� �� ������\n %08x\n��� ���������� ����������: %08x\n���: %d\n������ ������� ������: %d ����\n",
			(add), GetExceptionCode(), i, (add + 4 - iLMas) * 4 / 8);
	}
	/*ipMas = new int[size];
	printf("����\n"); 
	i = 0;
	__try {
		while (1) {
			add = &ipMas[i];
			ipMas[i] = i;
			i++;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\n�������� ���������� �� ������\n %08x\n��� ���������� ����������: %08x\n���: %d\n������ ������� ������: %d ����\n",
			(add), GetExceptionCode(), i, (add  -ipMas ) * 4 / 8);
	}
	printf("������� ����\n");
	i = 0; int j = 0;
	__try {
		while (1) {
			temp = &do_smth;
			add = reinterpret_cast<int*>(temp); 
			j = add + i;
			i++;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\n�������� ���������� �� ������\n %08x\n��� ���������� ����������: %08x\n���: %d\n������ ������� ������: %d ����\n",(add), GetExceptionCode(), i, (x - add) * 4 / 8);
	}*/
	
	getchar();
	return 0;
}