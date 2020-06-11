struct OFlags {
    int selectedSlot;
    int key;
    int regime;
};

enum regMode { selectingSlot, editingAcum, editingCounter };

struct Editor {
    int selectedDigit;
    int digits[4];
};

struct Editor editor;
struct OFlags outputFlags;

///////////////////////

#include "memory.h"
#include "myBigChars.h"
#include "myReadkey.h"
#include <math.h>
#include <signal.h>
#include <sys/time.h>

#define BUFFER_SIZE 50

int index;
int value[5];
int accumulator;
struct termios termios_default;
struct itimerval nval, oval;

typedef struct{
	int in_out;
	int value;
} Variables;

Variables buffer[BUFFER_SIZE];
int buff_counter;

void print_term();
void print_big(int a);
int *get_big(int a);
void do_command(enum keys k);
void inst_counter();
void _reset();
int ALU (int command, int operand);
void CU ();
void buff_clear();
