#include <stdio.h>

extern "C" {
	extern void Init_qyoto();
};

int 
main(int argc, char * argv[]) {
    printf("Starting up.\n");
    Init_qyoto();
    printf("Exiting.\n");
    return 0;
}
