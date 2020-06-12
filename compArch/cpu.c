#include "main.h"

void CU(byte *mem) {
	sc_regSet(FlagV, 0);
	sc_regSet(FlagO, 0);
	sc_regSet(FlagM, 0);
	sc_regSet(FlagE, 0);

	int tempMemory;
	int tempVariable;
	if (sc_memoryGet(mem, outputFlags.selectedSlot, &tempVariable) == -1) {
		sc_regSet(FlagT, 1);
	}
	int decodedVariable, decodedCommand;
	if (sc_commandDecode(tempVariable, &decodedCommand, &decodedVariable) == -1)
		sc_regSet(FlagT, 1);
	else
		switch (decodedCommand) {
			case READ:
				alarm(0);
				tcsetattr(STDIN_FILENO, TCSAFLUSH, &termios_default);
				printf(">> ");
				scanf("%d", &tempMemory);
				buffer[buff_counter].value = tempMemory;
				buffer[buff_counter].in_out = 1;
				buff_counter++;
				if (tempMemory > 0xffff || tempMemory < -0xffff) {
					sc_regSet(FlagV, 1);
					sc_regSet(FlagT, 1);
				} else if (sc_memorySet(mem, decodedVariable, tempMemory) == -1)
						sc_regSet(FlagT, 1);
				else {
					outputFlags.selectedSlot++;
				}
				  int flagsValue;
					sc_regGet(FlagT, &flagsValue):
				if (flagsValue == 0) {
					rk_mytermregime(0, 0, 0, 0, 0);
					setitimer(ITIMER_REAL, &nval, &oval);
				}
				break;
			case WRITE:
				if (sc_memoryGet(mem, decodedVariable, &tempMemory) == -1) {
					sc_regSet(FlagT, 1);
				}
				else {
					buffer[buff_counter].value = tempMemory;
					buffer[buff_counter].in_out = -1;
					buff_counter++;
					outputFlags.selectedSlot++;
				}
				break;
			case LOAD:
				if (sc_memoryGet(mem, decodedVariable, &tempMemory) == -1) {
					sc_regSet(FlagT, 1);
				}
				else {
					accumulator = tempMemory;
					outputFlags.selectedSlot++;
				}
				break;
			case STORE:
				if (sc_memorySet(mem, decodedVariable, accumulator) == -1) {
					sc_regSet(FlagT, 1);
				}
				else {
					outputFlags.selectedSlot++;
				}
				break;
			case JUMP:
				if (decodedVariable >= MaxMemory || decodedVariable < 1) {
					sc_regSet(FlagM, 1);
					sc_regSet(FlagT, 1);
				} else {
					outputFlags.selectedSlot = decodedVariable;
				}
				break;
			case JNEG:
				if (accumulator < 1) {
					if (decodedVariable >= MaxMemory || decodedVariable < 1) {
						sc_regSet(FlagM, 1);
						sc_regSet(FlagT, 1);
					} else
						outputFlags.selectedSlot = decodedVariable;
				} else
					outputFlags.selectedSlot++;
				break;
			case JZ:
				if (accumulator == 0) {
					if (decodedVariable >= MaxMemory || decodedVariable < 1) {
						sc_regSet(FlagM, 1);
						sc_regSet(FlagT, 1);
					} else {
						outputFlags.selectedSlot = decodedVariable;
					}
				} else {
					outputFlags.selectedSlot++;
				}
				break;
			case HALT:
				sc_regSet(FlagT, 1);
				break;
			default:
				if (ALU(decodedCommand, decodedVariable,mem) == -1) {
					sc_regSet(FlagT, 1);
				} else {
					outputFlags.selectedSlot++;
				}
				break;
		}
}

int ALU(int command, int operand,byte *mem) {
	int tempMemory;
	int tmp1;
	switch (command) {
		case ADD:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(FlagT, 1);
				return -1;
			} else {
				accumulator += tempMemory;
			}
			break;
		case SUBB:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(FlagT, 1);
				return -1;
			} else {
				accumulator -= tempMemory;
			}
			break;
		case DIVIDE:
			if(sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(FlagT, 1);
				return -1;
			} else if (tempMemory == 0) {
				sc_regSet(FlagO, 1);
				sc_regSet(FlagT, 1);
				return -1;
			} else {
				accumulator /= tempMemory;
			}
			break;
		case MUL:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(FlagT, 1);
				return -1;
			} else {
				accumulator *= tempMemory;
			}
			break;
		case SUBC:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1 || sc_memoryGet(mem, accumulator, &tmp1) == -1) {
				sc_regSet(FlagT, 1);
				return -1;
			}
			accumulator = tempMemory - tmp1;
			break;
	}
	return 0;
}
