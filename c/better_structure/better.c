#include <stdio.h>
#include <math.h>
#include <string.h>
#include <stdbool.h> //bool
#include <stdint.h> //SIZE_MAX
#include <limits.h>


typedef struct {
  char name[20];
  int day;
  int month;
  int year;
} bday_s;

double sum(double in[]) {
  double out = 0;
  for (int i=0; !isnan(in[i]); i++) out += in[i];
  return out;
}

void typemaster() {
  bool b = 256; //bool is sugar for _Bool thanks to stdbool.h
  if (b) {
    printf("b positive\n");
  }
}

void twinpointers() {
  char *list[] = { "first", "second", "third" };
  for (char **p=list; *p != NULL; p++) {
    printf("->%s\n", p[0]);
  }
}

void structify() {
  bday_s ben = { .name="Benjamin", .day=17, .month=1, .year=1983 };
  printf("structified '%s' sizeof := %lu bdate := %i/%i/%i\n",
      ben.name,
      sizeof(ben.day),
      ben.day,
      ben.month,
      ben.year);
}

int main() {
  double list[] = { 1.1, 2.2, 3.3, NAN };
  printf("sum: %f\n", sum(list));
  printf("sum: %f\n", sum((double[]){ 1.1, 2.2, 3.3, NAN })); //compound variable
  printf("string length = %lu\n", strlen("easy e"));
  printf("sizeof size_t: %lu SIZE_MAX: %lu\n", sizeof(size_t), SIZE_MAX);
  printf("char can have %i bits\n", CHAR_BIT);

  typemaster();
  //twinpointers();
  structify();
}
