
#include "BigChars.h"
#include "mySimpleComputer.h"
#include "terminal.h"

void draw(unsigned short *sc_memory);

void frame_draw();

void selectedMem_draw(int val);

void print_memory(unsigned short *sc_memory);

void print_flags();

void print_accumulator(int numb);

void print_ins_counter();

void print_operation(unsigned short *sc_memory);