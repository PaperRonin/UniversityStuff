#include "main.h"


    byte *mem;

void inst_counter() {
	  CU(mem);
    draw(mem);
}

void _reset() {
  mem = sc_memoryInit(MaxMemory);
	sc_regInit();
	outputFlags.selectedSlot = 1;
	sc_regSet(FlagT, 1);
	buff_clear();
	accumulator = 0;
  draw(mem);
  	tcsetattr(STDIN_FILENO, TCSAFLUSH, &termios_default);
}

void buff_clear() {
	buff_counter = 0;
	for(int h = 0; h < BUFFER_SIZE; h++) {
		buffer[h].in_out = 0;
		buffer[h].value = 0;
	}
}

int handleKey() {

  int check = 0;
	char file_name[50];
	int sl = 0;
    switch (outputFlags.key) {
    case KEY_l:
    printf("Введите имя файла: ");
    fgets(file_name, 20, stdin);
    sl = strlen(file_name);
    file_name[sl - 1] = '\0';
    check = sc_memoryLoad(mem, file_name);
    if(check != -1) {
      printf("Успешно.\n");
    }
        break;
    case KEY_s:
    printf("Введите имя файла: ");
    fgets(file_name, 20, stdin);
    sl = strlen(file_name);
    file_name[sl - 1] = '\0';
    check = sc_memorySave(mem,file_name);
    if (check != -1) {
      printf("Успешно.\n");
    }
        break;
    case KEY_r:
				sc_regSet(FlagT, 0);

				rk_mytermregime(0, 0, 0, 0, 0);

				signal(SIGALRM, inst_counter);

				nval.it_interval.tv_sec = 1;
				nval.it_interval.tv_usec = 0;
				nval.it_value.tv_sec = 1;
				nval.it_value.tv_usec = 0;

				setitimer(ITIMER_REAL, &nval, &oval);
        int tFlagVal;
				while(1) {
					sc_regGet(FlagT, &tFlagVal);
					if (outputFlags.selectedSlot > MaxMemory || tFlagVal == 1) {
						alarm(0);
						break;
					}
					signal(SIGALRM, inst_counter);

					int pressedKey;
					rk_readkey(&pressedKey);
					if (pressedKey == KEY_i) {
						alarm(0);
						signal(SIGUSR1, _reset);
						raise (SIGUSR1);
						break;
					}
				}
				tcsetattr(STDIN_FILENO, TCSAFLUSH, &termios_default);

        break;
    case KEY_t:
    inst_counter();
        break;
    case KEY_i:
    alarm(0);
    signal(SIGUSR1, _reset);
    raise (SIGUSR1);
        break;
    case KEY_q:
        return 1;
    case KEY_f5:
    printf("Введите значение акуммулятора: ");
    int newAccumVal;
    scanf("%x", &newAccumVal);
    while(newAccumVal > 0xffff || newAccumVal < -0xffff) {
      printf("Ошибка. Введите значение акуммулятора: ");
      scanf("%x", &newAccumVal);
    }
    accumulator = newAccumVal;
    draw(mem);
        break;
    case KEY_f6:
    printf("Введите новый индекс: ");
    int newIndexVal;
    scanf("%d", &newIndexVal);
    while(newIndexVal >= MaxMemory || newIndexVal < 0) {;
      printf("Ошибка. Введите новый индекс: ");
      scanf("%d", &newIndexVal);
    }
    outputFlags.selectedSlot = newIndexVal;
    draw(mem);
        break;
    case KEY_up:
        outputFlags.selectedSlot -= outputFlags.selectedSlot > 10 ? 10 : 0;
        draw(mem);
        break;
    case KEY_down:
        outputFlags.selectedSlot += outputFlags.selectedSlot < 91 ? 10 : 0;
        draw(mem);
        break;
    case KEY_left:
        outputFlags.selectedSlot -= outputFlags.selectedSlot > 1 ? 1 : 0;
        draw(mem);
        break;
    case KEY_right:
        outputFlags.selectedSlot += outputFlags.selectedSlot < 100 ? 1 : 0;
        draw(mem);
        break;
    case KEY_enter:
    printf("Ввежите признак команды: \n");
    int temp, temp1, temp2;
    scanf("%1d", &temp);
    if (temp == 1) {
      printf("Введите команду и операнд: \n");
      scanf("%2x%2x", &temp1, &temp2);
      if (sc_commandEncode(temp1, temp2, &temp) == 1) {
        sc_memorySet(mem, outputFlags.selectedSlot, temp);
      }
    }else if (temp == 0) {
      printf("Введите значение: \n");
      scanf("%4d", &temp2);

			temp2 = temp2 > 0xFFFF ? 0xFFFF : temp2;

      sc_memorySet(mem, outputFlags.selectedSlot, temp2);
    }
    draw(mem);
        break;
    }
    return 0;
}

int main(int argc, char const *argv[]) {
    sc_regInit();

    mem = sc_memoryInit(MaxMemory);
    outputFlags.selectedSlot = 1;
    sc_regSet(FlagT, 1);
    draw(mem);
    while (1) {
        rk_readkey(&outputFlags.key);
        if (handleKey() == 1) {
            break;
        }
    }
    rk_mytermrestore();
    return 0;
}
