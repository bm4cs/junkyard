P=multiply
CC=gcc
CFLAGS= -Wall -g -std=gnu11 -O0
LDFLAGS=
OBJECTS=

#$(P): $(OBJECTS)

multiply: multiply.c
	$(CC) $(CLFAGS) $? $(LDFLAGS) -o $@

all: multiply

clean:
	rm -f multiply
	rm -f *.log

