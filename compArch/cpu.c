#include "main.h"

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
	SUBC = 0x66,
};

void CU() {
	sc_regSet(FlagV, 0);
	sc_regSet(FlagO, 0);
	sc_regSet(FlagM, 0);
	sc_regSet(FlagE, 0);

	int tempMemory;
	int tempVariable;
	if (sc_memoryGet(mem, OFlags.selectedSlot, &tempVariable) == -1) {
		sc_regSet(Flag.T, 1);
	}
	int decodedVariable, decodedCommand;
	if (sc_commandDecode(tempVariable, &decodedCommand, &decodedVariable) == -1)
		sc_regSet(Flag.T, 1);
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
					sc_regSet(Flag.T, 1);
				} else if (sc_memorySet(mem, decodedVariable, tempMemory) == -1)
						sc_regSet(Flag.T, 1);
				else {
					OFlags.selectedSlot++;
				}

				if (value[3] == 0) {
					rk_mytermrergtime(0, 0, 0, 0, 0);
					setitimer(ITIMER_REAL, &nval, &oval);
				}
				break;
			case WRITE:
				if (sc_memoryGet(mem, decodedVariable, &tempMemory) == -1) {
					sc_regSet(Flag.T, 1);
				}
				else {
					buffer[buff_counter].value = tempMemory;
					buffer[buff_counter].in_out = -1;
					buff_counter++;
					OFlags.selectedSlot++;
				}
				break;
			case LOAD:
				if (sc_memoryGet(mem, decodedVariable, &tempMemory) == -1) {
					sc_regSet(Flag.T, 1);
				}
				else {
					accumulator = tempMemory;
					OFlags.selectedSlot++;
				}
				break;
			case STORE:
				if (sc_memorySet(mem, decodedVariable, accumulator) == -1) {
					sc_regSet(Flag.T, 1);
				}
				else {
					OFlags.selectedSlot++;
				}
				break;
			case JUMP:
				if (decodedVariable >= SIZE || decodedVariable < 0) {
					sc_regSet(FlagM, 1);
					sc_regSet(Flag.T, 1);
				} else {
					OFlags.selectedSlot = decodedVariable;
				}
				break;
			case JNEG:
				if (accumulator < 0) {
					if (decodedVariable >= SIZE || decodedVariable < 0) {
						sc_regSet(FlagM, 1);
						sc_regSet(Flag.T, 1);
					} else
						OFlags.selectedSlot = decodedVariable;
				} else
					OFlags.selectedSlot++;
				break;
			case JZ:
				if (accumulator == 0) {
					if (decodedVariable >= SIZE || decodedVariable < 0) {
						sc_regSet(FlagM, 1);
						sc_regSet(Flag.T, 1);
					} else {
						OFlags.selectedSlot = decodedVariable;
					}
				} else {
					OFlags.selectedSlot++;
				}
				break;
			case HALT:
				sc_regSet(Flag.T, 1);
				break;
			default:
				if (ALU(decodedCommand, decodedVariable) == -1) {
					sc_regSet(Flag.T, 1);
				} else {
					OFlags.selectedSlot++;
				}
				break;
		}
}

int ALU(int command, int operand) {
	int tempMemory;
	int tmp1;
	switch (command) {
		case ADD:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(Flag.T, 1);
				return -1;
			} else {
				accumulator += tempMemory;
			}
			break;
		case SUBB:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(Flag.T, 1);
				return -1;
			} else {
				accumulator -= tempMemory;
			}
			break;
		case DIVIDE:
			if(sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(Flag.T, 1);
				return -1;
			} else if (tempMemory == 0) {
				sc_regSet(FlagO, 1);
				sc_regSet(Flag.T, 1);
				return -1;
			} else {
				accumulator /= tempMemory;
			}
			break;
		case MUL:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1) {
				sc_regSet(Flag.T, 1);
				return -1;
			} else {
				accumulator *= tempMemory;
			}
			break;
		case SUBC:
			if (sc_memoryGet(mem, operand, &tempMemory) == -1 || sc_memoryGet(mem, accumulator, &tmp1) == -1) {
				sc_regSet(Flag.T, 1);
				return -1;
			}
			accumulator = tempMemory - tmp1;
			break;
	}
	return 0;
}
