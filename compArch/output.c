#include "output.h"
#include "main.h"

void draw(unsigned short *sc_memory) {

    int rows = 27, cols = 100;

    mt_setscreensize(rows, cols);

    frame_draw();

    int val;

    sc_memoryGet(sc_memory, outputFlags.selectedSlot, &val);

    print_accumulator(val);

    print_ins_counter();

    print_operation(sc_memory);

    print_flags();

    print_memory(sc_memory);

    selectedMem_draw(val);

    mt_gotoXY(0, rows - 1);

    printf("\n");
}

void selectedMem_draw(int val) {
    char strval[10];

    if (val < 0) {
      sprintf(strval, "%04d", val);
        bc_convertandprintbigchar('-', 2, 14, cl_default, cl_black);
    } else {
      sprintf(strval, "%04x", val);
        bc_convertandprintbigchar('+', 2, 14, cl_default, cl_black);
    }

    bc_convertandprintbigchar(strval[0], 11, 14, cl_default, cl_black);

    bc_convertandprintbigchar(strval[1], 20, 14, cl_default, cl_black);

    bc_convertandprintbigchar(strval[2], 29, 14, cl_default, cl_black);

    bc_convertandprintbigchar(strval[3], 38, 14, cl_default, cl_black);
}

void print_flags() {

    mt_gotoXY(76, 11);

    int flagsValue[5];

    sc_regGet(FlagV, &flagsValue[0]);
    sc_regGet(FlagO, &flagsValue[1]);
    sc_regGet(FlagM, &flagsValue[2]);
    sc_regGet(FlagT, &flagsValue[3]);
    sc_regGet(FlagE, &flagsValue[4]);

    if(flagsValue[0] == 0) {
		printf("V");
    }
	else {
		mt_setbgcolor(cl_green);
		printf("V");
		mt_setbgcolor(cl_default);
	}
	printf(" ");
	if(flagsValue[1] == 0) {
		printf("O");
	}
	else {
		mt_setbgcolor(cl_green);
		printf("O");
		mt_setbgcolor(cl_default);
	}
	printf(" ");
	if(flagsValue[2] == 0)
		printf("M");
	else {
		mt_setbgcolor(cl_green);
		printf("M");
		mt_setbgcolor(cl_default);
	}
	printf(" ");
	if(flagsValue[3] == 0) {
		printf("T");
	}
	else {
		mt_setbgcolor(cl_green);
		printf("T");
		mt_setbgcolor(cl_default);
	}
	printf(" ");
	if(flagsValue[4] == 0)
		printf("E");
	else {
		mt_setbgcolor(cl_green);
		printf("E");
		mt_setbgcolor(cl_default);
	}
}

void print_memory(unsigned short *sc_memory) {

    int val;

    mt_gotoXY(2, 2);

    for (int i = 0, k = 2; i < MaxMemory - 1; ++i) {

        if (i % 10 == 0 && i >= 10) {

            mt_gotoXY(2, ++k);
        }

        if (i == outputFlags.selectedSlot - 1) {
            mt_setfgcolor(cl_black);
            mt_setbgcolor(cl_light_blue);
          }

        sc_memoryGet(sc_memory, i + 1, &val);
        if (val < 0) {
        printf("%.4d", val);
        } else {
        printf("+%.4x", val);
        }

        if (i == outputFlags.selectedSlot - 1) {
            mt_setfgcolor(cl_default);
            mt_setbgcolor(cl_default);
        }
        printf(" ");
    }
}

void print_accumulator() {

    mt_gotoXY(77, 2);

    printf("%.4x", accumulator);

}

void print_ins_counter() {

    mt_gotoXY(77, 5);

        printf("+%.4d ", outputFlags.selectedSlot-1);

}

void print_operation(unsigned short *sc_memory) {

    mt_gotoXY(77, 8);

    int value = 0;
    sc_memoryGet(sc_memory, outputFlags.selectedSlot, &value);
    int cmd = 0;
    int operand = 0;
    if (!sc_commandDecode(value, &cmd, &operand)) {
        printf("+%.2x:%.2d", cmd, operand);
    } else {
        printf("+00:00");
    }
}

void frame_draw() {

    mt_setbgcolor(cl_black);

    mt_setfgcolor(cl_default);

    mt_clrscr();

    bc_box(1, 1, 62, 12);

    mt_gotoXY(29, 1);

    printf("Memory");

    bc_box(63, 1, 96, 3);

    mt_gotoXY(75, 1);

    printf("Accumulator");

    bc_box(63, 4, 96, 6);

    mt_gotoXY(71, 4);

    printf("InstructionCounter");

    bc_box(63, 7, 96, 9);

    mt_gotoXY(76, 7);

    printf("Operation");

    bc_box(63, 10, 96, 12);

    mt_gotoXY(78, 10);

    printf("Flags");

    bc_box(47, 13, 96, 22);

    mt_gotoXY(1, 30);

    bc_box(1, 13, 46, 22);

    mt_gotoXY(48, 13);

    printf("Keys: ");

    mt_gotoXY(48, 15);

    printf("l - load");

    mt_gotoXY(48, 16);

    printf("s - save");

    mt_gotoXY(48, 17);

    printf("r - run");

    mt_gotoXY(48, 18);

    printf("t - step");

    mt_gotoXY(48, 19);

    printf("i - reset");

    mt_gotoXY(48, 20);

    printf("F5 - accumulator");

    mt_gotoXY(48, 21);

    printf("F6 - instructionCounter");

    mt_gotoXY(24, 1);
    printf("Input\\Output:\n\n");

    for(int h = 0; h < BUFFER_SIZE && buffer[h].in_out != 0; h++) {
		if (buffer[h].in_out == 1) {
			printf(">> ");
		}
		else {
			printf("<< ");
		}
		printf("%d\n", buffer[h].value);
	}

}
