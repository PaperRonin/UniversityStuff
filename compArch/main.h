struct OFlags {
    int selectedSlot;
    int key;
};

struct OFlags outputFlags;

///////////////////////

#include "BigChars.h"
#include "myReadkey.h"
#include "mySimpleComputer.h"
#include "output.h"
#include "terminal.h"
#include <math.h>
#include <signal.h>
#include <sys/time.h>

#define BUFFER_SIZE 50

enum Commands {
	READ = 0x10,
	WRITE,
	LOAD = 0x20,
	STORE,
	ADD = 0x30,
	SUBB,
	DIVIDE,
	MUL,
	JUMP = 0x40,
	JNEG,
	JZ,
	HALT,
	SUBC = 0x66
};

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
void do_command(enum keys k,byte *mem);
void inst_counter();
void _reset();
int ALU (int command, int operand,byte *mem);
void CU (byte *mem);
void buff_clear();
