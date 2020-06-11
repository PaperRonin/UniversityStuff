#include "commands.h"

void do_command(enum keys k) {
	int check = 0;
	char file_name[50];
	int sl = 0;

	switch (k) {
		case _l:
			printf("Введите имя файла: ");
			fgets(file_name, 20, stdin);
			sl = strlen(file_name);
			file_name[sl - 1] = '\0';
			check = sc_memoryLoad(file_name);
			if(check != -1) {
				printf("Успешно.\n\n");
			}
			break;
		case _s:
			printf("Введите имя файла: ");
			fgets(file_name, 20, stdin);
			sl = strlen(file_name);
			file_name[sl - 1] = '\0';
			check = sc_memorySave(file_name);
			if (check != -1) {
				printf("Успешно.\n\n");
			}
			break;
		case _r:
				sc_regSet(IG, 0);

				rk_mytermrergtime(0, 0, 0, 0, 0);

				signal(SIGALRM, inst_counter);

				nval.it_interval.tv_sec = 1;
				nval.it_interval.tv_usec = 0;
				nval.it_value.tv_sec = 1;
				nval.it_value.tv_usec = 0;

				setitimer(ITIMER_REAL, &nval, &oval);

				while(1) {
					sc_regGet(IG, &value[3]);
					if (OFlags.selectedSlot >= SIZE - 1 || value[3] == 1) {
						alarm(0);
						break;
					}
					signal(SIGALRM, inst_counter);

					enum keys _temp;
					rk_readkey(&_temp);
					if (_temp == _i) {
						alarm(0);
						signal(SIGUSR1, _reset);
						raise (SIGUSR1);
						break;
					}
				}
				tcsetattr(STDIN_FILENO, TCSAFLUSH, &termios_default);

			break;
		case _t:
			inst_counter();
			break;
		case _i:
			alarm(0);
			signal(SIGUSR1, _reset);
			raise (SIGUSR1);
			break;
		case _q:
			printf("Введите новое значение: \n");
			int tmp;
			scanf("%x", &tmp);
			if (tmp > 0xFFFF) {
				tmp = 0xFFFF;
			}
			arr[OFlags.selectedSlot] = tmp;
			break;
		case _c:
			buff_clear();
			break;
		case F5:
			printf("Введите accumulator: ");
			int t_ac;
			scanf("%x", &t_ac);
			while(t_ac > 0xffff || t_ac < -0xffff) {
				printf("Ошибка. Введите accumulator: ");
				scanf("%x", &t_ac);
			}
			accumulator = t_ac;
			break;
		case F6:
			printf("Введите новый индекс: ");
			int in_c;
			scanf("%d", &in_c);
			while(in_c >= SIZE || in_c < 0) {;
				printf("Ошибка. Введите новый индекс: ");
				scanf("%d", &in_c);
			}
			OFlags.selectedSlot = in_c;
			break;
		case UP:
			if (OFlags.selectedSlot - 10 >= 0)
				OFlags.selectedSlot -= 10;
			else
				OFlags.selectedSlot += 90;
			break;
		case DOWN:
			if (OFlags.selectedSlot + 10 < 100)
				OFlags.selectedSlot += 10;
			else
				OFlags.selectedSlot -= 90;
			break;
		case LEFT:
			if (OFlags.selectedSlot % 10 != 0)
				OFlags.selectedSlot--;
			else
				OFlags.selectedSlot += 9;
			break;
		case RIGHT:
			if (OFlags.selectedSlot % 10 != 9)
				OFlags.selectedSlot++;
			else
				OFlags.selectedSlot -= 9;
			break;
		case ENTER:
			printf("Команда и операнд: \n");
			int temp = 0, temp1, temp2;
			scanf("%2x%2x", &temp1, &temp2);
			if (sc_commandEncode(temp1, temp2, &temp) == 1) {
				sc_memorySet(OFlags.selectedSlot, temp);
			}

			break;
	}
	return;
}

void inst_counter() {
	CU();
    print_term();
}

void _reset() {
	sc_memoryInit();
	sc_regInit();
	OFlags.selectedSlot = 0;
	sc_regSet(IG, 1);
	buff_clear();
	accumulator = 0;
}

void buff_clear() {
	buff_counter = 0;
	for(int h = 0; h < BUF_SIZE; h++) {
		buffer[h].in_out = 0;
		buffer[h].value = 0;
	}
}
