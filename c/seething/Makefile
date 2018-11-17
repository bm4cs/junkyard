P=seething
CC=gcc

# compiler flags
CFLAGS= -Wall -g -std=gnu11 -O0 -Iinclude
CFLAGS+= `pkg-config --cflags glib-2.0` # pkg-config to resolve needed compiler includes
#CFLAGS+= -I/usr/include/glib-2.0 -I/lib64/glib-2.0/include # hard-coded version

# linker flags
LDFLAGS=
LDFLAGS+= `pkg-config --libs glib-2.0` 
#LDFLAGS+= -lglib-2.0 # hard-coded version


LDADD=-Llibpath -Wl,-Rlibpath


VPATH=src:include
OBJECTS=main.o

all: $(P)

$(P): $(OBJECTS)
	$(CC) -o $(P) $(OBJECTS)


#
# The below one liner, with no recipe defined, will result in:
#   gcc -Wall -g -std=gnu11 -O0 -Iinclude `pkg-config --cflags glib-2.0` -c -o main.o src/main.c
#
# $< returns the name of the first prerequisite
# See https://www.gnu.org/software/make/manual/make.html#Automatic-Variables
#
main.o: main.c allheads.h
#	$(CC) $(CFLAGS) -c $< # make is smart enough to infer this (i.e. CFLAGS, etc) 



.PHONY: clean
clean:
	rm -f $(P)
	rm -f $(OBJECTS)
	rm -f *.log


#
# make comes with a bucket of functions for transforming text
# https://www.gnu.org/software/make/manual/make.html#Functions
# Below uses filter-out to strip out a couple of CFLAG options.
#


day=$(shell date +%A)

.PHONY: stringfun
stringfun:
	$(info $(filter-out -Wall -g -O0,$(CFLAGS)))
#	$(day = $(shell date +%A))
	$(info Ben it's $(day)!)
	

# This quick reference is the bomb.
# https://www.gnu.org/software/make/manual/make.html#toc-Quick-Reference-1






