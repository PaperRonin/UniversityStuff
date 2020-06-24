#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef unsigned short byte;


char str[100];
byte arr[100];

char sti(char *str, int *num);
int lex(int i);

int main(int argc, const char *argv[])  {
	if(argc != 3) {
		printf("Синтаксис: ./file input.ba output.sa\n");
		return 1;
	}

	char sa_file[50];
	char o_file[50];

	strcpy(sa_file, argv[1]);
	strcpy(o_file, argv[2]);

	FILE *f;
	f = fopen(sa_file, "r");
	if (!f) {
		printf("Ошибка открытия файла.\n");
		return 1;
	}
	int i = 0;
	int check = 0;
	for (int j = 0; j < 100; j++)
		arr[j] = 0;
	while(fgets(str, 100, f) != NULL) {
		check = lex(i);
		if(check == -1) {
			printf("Ошибка синтаксиса: %d str\n", i);
			break;
		}
		i++;
	}
	fclose(f);
	if (check != -1) {
		f = fopen(o_file, "wb");
		if (!f) {
			printf("Ошибка открытия файла.\n");
			return 1;
		}

		fwrite(arr, sizeof(int), 100, f);
		printf("Трансляция успешно завершена.\n");

		fclose(f);
	}
	return 0;
}


char sti(char *str, int *num) {
	*num = 0;
	int radix = 1;
	int n = strlen(str);
	for(int i = n - 1; i >= 0; i--) {
		if(str[i] == '\n') {
			continue;
		}
		*num += (str[i] - 48) * radix;
		if(str[i] < 47 || str[i] > 58) {
			*num = 0;
			return 's';
		}
		radix *= 10;
	}
	return 'i';
}

int lex(int i) {
	char *tok;
	char check;
	int temp = 0;
	int com, op = 0;
	tok = strtok(str, " ");
	check = sti(tok, &temp);
	if(check == 's' || temp != i) {
		printf("Неправильный индекс\n");
		return -1;
	}

	tok = strtok(NULL, " ");
	if (strcmp(tok, "READ") == 0)
		com = 0x10;
	else if (strcmp(tok, "WRITE") == 0)
		com = 0x11;
	else if (strcmp(tok, "LOAD") == 0)
		com = 0x20;
	else if (strcmp(tok, "STORE") == 0)
		com = 0x21;
	else if (strcmp(tok, "ADD") == 0)
		com = 0x30;
	else if (strcmp(tok, "SUB") == 0)
		com = 0x31;
	else if (strcmp(tok, "DIVIDE") == 0)
		com = 0x32;
	else if (strcmp(tok, "MUL") == 0)
		com = 0x33;
	else if (strcmp(tok, "JUMP") == 0)
		com = 0x40;
	else if (strcmp(tok, "JNEG") == 0)
		com = 0x41;
	else if (strcmp(tok, "JZ") == 0)
		com = 0x42;
	else if (strcmp(tok, "HALT") == 0)
		com = 0x43;
	else if (strcmp(tok, "OR") == 0)
		com = 0X53;
	else if (strcmp(tok, "=") == 0)
		com = 0;
	else {
		printf("Неправильная команда\n");
		return -1;
	}

	tok = strtok(NULL, " ");

	if(tok[0] == '+') {
		check = sti(tok + 1, &op);
	}else if (tok[0] == '-') {
		check = sti(tok + 1, &op);
		op = - op;
	}else
		check = sti(tok, &op);

	if(check == 's') {
		printf("Ошибка операнда\n");
		return -1;
	}
	if(op > 127) {
		printf("Ошибка операнда\n");
		return -1;
	}

	arr[i] = (com << 7) | op;

	tok = strtok(NULL, " ");
	if (tok != NULL && tok[0] != ';') {
		printf("Ошибка комментария\n");
		return -1;
	}

	return 0;
}
