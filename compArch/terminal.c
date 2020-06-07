#include "terminal.h"

void mt_clrscr() { printf("\ec"); }

int mt_gotoXY(int x, int y) {
    int rows, cols;

    mt_getscreensize(&rows, &cols);
    if ((y < rows) && (x < cols) && (x >= 0) && (y >= 0)) {
        printf("\e[%d;%dH", y, x);
        return 0;
    } else
        return 1;
}

int mt_getscreensize(int *rows, int *cols) {
    struct winsize w;

    if (!ioctl(STDOUT_FILENO, TIOCGWINSZ, &w)) {
        *rows = w.ws_row;
        *cols = w.ws_col;
        return 0;
    } else
        return 1;
}

int mt_setscreensize(int rows, int cols) {

    if (rows < 600 && rows > 10 && cols < 1200 && cols > 10) {
        printf("\e[8;%d;%dt", rows, cols);
        return 0;
    } else
        return 1;
}

int mt_setfgcolor(enum colors color) {
    switch (color) {
    case cl_black:
        printf("\e[30m");
        break;
    case cl_red:
        printf("\e[31m");
        break;
    case cl_green:
        printf("\e[32m");
        break;
    case cl_brown:
        printf("\e[33m");
        break;
    case cl_blue:
        printf("\e[34m");
        break;
    case cl_magenta:
        printf("\e[35m");
        break;
    case cl_cyan:
        printf("\e[36m");
        break;
    case cl_light_blue:
        printf("\e[37m");
        break;
    case cl_default:
        printf("\e[39m");
        break;
    default:
        return -1;
    }
    return 0;
}

int mt_setbgcolor(enum colors color) {
    switch (color) {
    case cl_black:
        printf("\e[40m");
        break;
    case cl_red:
        printf("\e[41m");
        break;
    case cl_green:
        printf("\e[42m");
        break;
    case cl_brown:
        printf("\e[43m");
        break;
    case cl_blue:
        printf("\e[44m");
        break;
    case cl_magenta:
        printf("\e[45m");
        break;
    case cl_cyan:
        printf("\e[46m");
        break;
    case cl_light_blue:
        printf("\e[47m");
        break;
    case cl_default:
        printf("\e[49m");
        break;
    default:
        return -1;
    }
    return 0;
}