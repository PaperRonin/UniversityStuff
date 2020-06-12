#include "main.h"


    byte *mem;

void sigHandler(int sigN) {
    if (sigN == SIGINT)
        printf("received SIGINT\n"); // FIXME
    if (sigN == SIGUSR1)
        printf("restart\n"); // FIXME
}

int handleKey(byte *mem) {

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
      printf("Успешно.\n\n");
    }
        break;
    case KEY_s:
    printf("Введите имя файла: ");
    fgets(file_name, 20, stdin);
    sl = strlen(file_name);
    file_name[sl - 1] = '\0';
    check = sc_memorySave(mem,file_name);
    if (check != -1) {
      printf("Успешно.\n\n");
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
        break;
    case KEY_i:
        break;
    case KEY_q:
        return 1;
    case KEY_f5:

        break;
    case KEY_f6:

        break;
    case KEY_up:
        outputFlags.selectedSlot -= outputFlags.selectedSlot > 10 ? 10 : 0;
        break;
    case KEY_down:
        outputFlags.selectedSlot += outputFlags.selectedSlot < 91 ? 10 : 0;
        break;
    case KEY_left:
        outputFlags.selectedSlot -= outputFlags.selectedSlot > 1 ? 1 : 0;
        break;
    case KEY_right:
        outputFlags.selectedSlot += outputFlags.selectedSlot < 100 ? 1 : 0;
        break;
    case KEY_enter:

        break;
    }
    return 0;
}

int main(int argc, char const *argv[]) {
    if (signal(SIGINT, sigHandler) == SIG_ERR) {
        printf("\ncan't catch SIGINT\n");
        return -1;
    }
    if (signal(SIGUSR1, sigHandler) == SIG_ERR) {
        printf("\ncan't catch SIGUSR1\n");
        return -1;
    }
    sc_regInit();

mem = sc_memoryInit(MaxMemory);
    outputFlags.selectedSlot = 1;
    draw(mem);
    raise(SIGUSR1);
    raise(SIGINT);
    while (1) {
        draw(mem);
        rk_readkey(&outputFlags.key);
        if (handleKey(mem) == 1) {
            break;
        }
    }
    return 0;
}
