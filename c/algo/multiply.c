#include <stdio.h>
#include <assert.h>
#include <limits.h>
#include <stdlib.h> //malloc and free

int intlist[10];

void double_in(int *in) {
  *in *= 2;
}

int main() {
  static_assert(sizeof(void*) == 8, "64-bit code generation not supported");
  printf("stdc = %li, bits per byte = %i\n", __STDC_VERSION__, CHAR_BIT);

  //strings
  int len = 20;
  char foo_string[len];
  intlist[7] = 7;
  snprintf(foo_string, len, "Item seven is %i.", intlist[7]);
  printf("das string equals: <<%s>>\n", foo_string);


  //memory
  int *intspace = malloc(3000 * sizeof(int));

  for (int i=0; i < 3000; i++)
    intspace[i] = i;

  FILE *counter_file = fopen("counter.log", "a");

  for (int i=0; i < 3000; i++)
    fprintf(counter_file, "%i\n", intspace[i]);

  free(intspace);
  fclose(counter_file);


  //streams
  FILE *file = fopen("error.log", "a");
  error_print(file, "something went pop then fizzle", 19);
  fclose(file);


  // pointers
  int list[100];
  int *list2 = list;
  *list2 = 7;
  assert(list[0] == 7);

  int x = 10;
  double_in(&x);
  printf("x now points to %i.\n", x);


  // das void pointer
  void *anything;
  anything = &x;
  (*((int*)anything))++;
  printf("x now points to %i.\n", x);
}
