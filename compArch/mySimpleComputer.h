#ifndef MEMORY_H
#define MEMORY_H

typedef unsigned short byte;

#include <stdio.h>
#include <stdlib.h>

#define MaxMemory 101

typedef struct { //Регистр флагов содержит 5 разрядов:
    unsigned V : 1; //переполнение при выполнении операции
    unsigned Z : 1; //ошибка деления на 0
    unsigned E : 1; //ошибка выхода за границы памяти
    unsigned P : 1; //игнорирование тактовых импульсов
    unsigned C : 1;  //указана неверная команда
    unsigned F1 : 1; //ЗАРЕЗЕРВИРОВАНО
    unsigned F2 : 1; //ЗАРЕЗЕРВИРОВАНО
    unsigned F3 : 1; //ЗАРЕЗЕРВИРОВАНО
} tFlags;

enum FlagMask {
    FlagV = 0b00000001,
    FlagZ = 0b00000010,
    FlagE = 0b00000100,
    FlagP = 0b00001000,
    FlagC = 0b00010000
};

tFlags Flags;

byte *Memory;

byte *sc_memoryInit(int size);
int sc_memorySet(byte *mem, int addr, int value);
int sc_memoryGet(byte *mem, int addr, int *value);
int sc_memorySave(byte *mem, char *filename);
int sc_memoryLoad(byte *mem, char *filename);
void sc_regInit();
int sc_regSet(int reg, int value);
int sc_regGet(int reg, int *value);
int sc_commandEncode(int command, int operand, int *value);
int sc_commandDecode(int value, int *command, int *operand);

#endif