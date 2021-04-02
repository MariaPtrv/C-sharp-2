//// Проект для лабораторной работы по знакомству с исключительными ситуациями
//#include <conio.h>
//#include <locale.h> // Для русского вывода
//#include <signal.h>
//#include <windows.h> // for EXCEPTION_ACCESS_VIOLATION
//#include <excpt.h>
//#include <iostream>
//using namespace std;
//int iMas[10]; // Объявите глобальный массив
//int i = 0;
//int* add;// Объявите вспомогательные переменные
//int doSmth(int param) {
//	return param *= param;
//}
//int main() {
//	int* dinamic = new int(10);
//	int iLMas[10]; // Объявите локальный массив
//	setlocale(LC_ALL, ".1251"); // Чтобы выводилось по-русски
//
//		// Выполняйте обращение к данным по разным адресам
//		__try {
//			while (1) {
//			iMas[i] = i; /* Обращение к области глобальных данных */cout << iMas[i] << endl; add = &iMas[i];
//			//iLMas[i] = i; /*Обращение к области локальных данных */cout <<iLMas[i] << endl; add = &iLMas[i];
//			//cout << dinamic++ << endl; //Обращение к данным, для которых память выделена динамически
//			// add = reinterpret_cast<int*>(*doSmth); /*Обращение к области кода */ cout << add + i<< endl;
//			i++;
//
//			}
//		}
//
//		__catch (...) {
//			cout << "Обработка исключений:" << endl;
//
//			cout << "Нарушение прав доступа к записи, расположенной по адресу " << hex << add + 4 << endl;
//			cout << "Адрес глобального массива iMas: " << iMas << endl;
//			//cout << "Адрес локального массива iLMas: "<< iLMas << endl;
//			//cout << "Первичный адрес указателя: " << address << endl;
//			cout << "Размер области памяти: " << dec << (add + 4 - iMas) * 4 / 8 << " байт" << endl;
//			//cout << "Размер области памяти: " << dec <<(x - address) * 4 / 8 << " байт" « endl;
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
	/*printf("Глобальный массив\n");
	i = 0;
		__try {
			while (1) { 
				add = &iMas[i];
				iMas[i] = i; 
				i++; 
			}
	}
		__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\nВозникло исключение по адресу\n %08x\nКод возникшего исключения: %08x\nШаг: %d\nРазмер области памяти: %d байт\n", 
			(iMas[i] + i), GetExceptionCode(), i, (add + 4 - iMas) * 4 / 8);
	}*/
	printf("Локальный массив\n");
	i = 0;
	__try {
		while (1) {
			add = &iLMas[i];
			printf("%d",iLMas[i]+i);
			i++;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\nВозникло исключение по адресу\n %08x\nКод возникшего исключения: %08x\nШаг: %d\nРазмер области памяти: %d байт\n",
			(add), GetExceptionCode(), i, (add + 4 - iLMas) * 4 / 8);
	}
	/*ipMas = new int[size];
	printf("Куча\n"); 
	i = 0;
	__try {
		while (1) {
			add = &ipMas[i];
			ipMas[i] = i;
			i++;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER) {
		printf("\nВозникло исключение по адресу\n %08x\nКод возникшего исключения: %08x\nШаг: %d\nРазмер области памяти: %d байт\n",
			(add), GetExceptionCode(), i, (add  -ipMas ) * 4 / 8);
	}
	printf("Участок кода\n");
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
		printf("\nВозникло исключение по адресу\n %08x\nКод возникшего исключения: %08x\nШаг: %d\nРазмер области памяти: %d байт\n",(add), GetExceptionCode(), i, (x - add) * 4 / 8);
	}*/
	
	getchar();
	return 0;
}