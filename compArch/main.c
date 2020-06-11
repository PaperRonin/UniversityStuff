#include "main.h"

void sigHandler(int sigN) {
    if (sigN == SIGINT)
        printf("received SIGINT\n"); // FIXME
    if (sigN == SIGUSR1)
        printf("restart\n"); // FIXME
}

int handleKey(byte *mem) {
    if (outputFlags.regime != selectingSlot) {
        if (outputFlags.key < 10) {
            editor.digits[editor.selectedDigit] = outputFlags.key;
        } else {
            switch (outputFlags.key) {
            case KEY_left:
                editor.selectedDigit -= editor.selectedDigit > 0 ? 1 : 0;
                return 0;
            case KEY_right:
                editor.selectedDigit += editor.selectedDigit < 3 ? 1 : 0;
                return 0;
            case KEY_up:
            case KEY_down:
                return 0;
            }
        }
    }

    switch (outputFlags.key) {
    case KEY_l:
        sc_memoryLoad(mem, "save");
        break;
    case KEY_s:
        sc_memorySave(mem, "save");
        break;
    case KEY_r:
        break;
    case KEY_t:
        break;
    case KEY_i:
        break;
    case KEY_q:
        return 1;
    case KEY_f5:
        outputFlags.regime = editingAcum;
        int valToGet;
        editor.selectedDigit = 3;
        sc_memoryGet(mem, outputFlags.selectedSlot, &valToGet);
        for (int i = 3; i >= 0; --i) {
            editor.digits[i] = div(valToGet, 10).rem;
            valToGet /= 10;
        }
        break;
    case KEY_f6:
        outputFlags.regime = editingCounter;
        editor.selectedDigit = 3;
        int countVal = outputFlags.selectedSlot;
        for (int i = 3; i >= 0; --i) {
            editor.digits[i] = div(countVal, 10).rem;
            countVal /= 10;
        }
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
        if (outputFlags.regime == selectingSlot) {
            break;
        }
        int pos = 1000;
        int valToSet = 0;
        for (int i = 0; i < 4; ++i) {
            valToSet += pos * editor.digits[i];
            pos /= 10;
        }
        if (outputFlags.regime == editingAcum) {
            sc_memorySet(mem, outputFlags.selectedSlot, valToSet);
        } else {
            if (valToSet > 0 && valToSet < 101) {
                outputFlags.selectedSlot = valToSet;
            } else {
                sc_regSet(FlagE, 1);
            }
        }

        outputFlags.regime = selectingSlot;
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

    editor.selectedDigit = 3;
    for (int i = 3; i > 0; --i) {
        editor.digits[i] = 0;
    }

    *mem = sc_memoryInit(MaxMemory);
    outputFlags.selectedSlot = 1;
    outputFlags.regime = selectingSlot;
    draw(mem);
    raise(SIGUSR1);
    raise(SIGINT);
    int w = 0;
    sc_commandEncode(0x30, 4, &w);
    sc_memorySet(mem, 1, w);
    sc_memorySet(mem, 2, 1223);
    while (1) {
        draw(mem);
        rk_readkey(&outputFlags.key);
        if (handleKey(mem) == 1) {
            break;
        }
    }
    return 0;
}
