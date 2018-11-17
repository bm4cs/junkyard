

#include "allheads.h"



// https://developer.gnome.org/glib/stable/index.html



GList *list;

int get_rand() {
  srand(time(NULL));
  return rand() % 100;
  return 1;
}

void print_time() {

//  tm foo;

  time_t rawtime;
  time(&rawtime);
  struct tm* da_time = localtime(&rawtime);

  printf("The local time is %i:%i:%i\n", da_time->tm_hour, da_time->tm_min, da_time->tm_sec);
}





/*
 * Read the contents of /etc/passwd.
 */
void file_io_fun() {
  int fd = open("/etc/passwd", O_RDONLY);
  if (fd == -1) {
    perror("file_io_fun");
    return;
  }

  char buf[65536];
  char *buffy = buf;
  ssize_t nr;
  int len = sizeof(buf);

  while (len != 0 && (nr = read(fd, buffy, len) != 0)) {
    if (nr == -1) {
      if (errno == EINTR) {
        printf("EINTR while read()\n");
        continue;
      }

      perror("read");
      break;
    }

    len -= nr;
    buffy += nr;
  }

//  nr = read(fd, buf, sizeof(buf));
//  if (nr == -1) {
//
//    return;
//  }

  printf("read() := %s\n", buf);

}


// syslog.h
// journalctl --since
// Oct 30 21:37:47 think.local bls[31764]: A tree falls in the forest
void logit(const char *msg) {
  setlogmask(LOG_UPTO (LOG_NOTICE));
  openlog("bls", LOG_CONS | LOG_PID | LOG_NDELAY, LOG_LOCAL1);
  syslog(LOG_WARNING, msg);
  closelog();
}




//blog1 typedefs
typedef unsigned char UCHAR;
typedef struct { double x, y; } POINT;

void blog1() {
  printf("blog1 typedefs\n");
  UCHAR c1, c2, tab[100];
  POINT point, *pPoint;
  c1 = 'b';
  pPoint = &point;
  printf("done\n");
}


// basic types
void blog2() {
  printf("blog2 basic types\n");
  _Bool flag = true;
  if (flag) printf("truthy\n");

  long long beast = 9223372036854775806;
  long long *thing = &beast;
  printf("%llu = %llu\n", *thing, beast);

  //stdint.h
  int16_t val = -10;
  int_fast32_t val2 = 2147483648;
  printf("%i %li\n", val, val2);

  printf("done\n");
}

// strings
void blog3() {
  char a = 'o';
  wchar_t b = L'\x007E';

  wchar_t *message = "i am a string of " "wide characters";
  
  printf("  %c\n  %s\n", b, message);
}


// memory operands
void blog4() {
  int32_t num, *pnum;
  pnum = &num;
  *pnum = 123;
  printf("  blog4() := %i\n", *pnum);

  float arr[10] = { 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7 }, *parr;
  parr = arr;
  parr = parr + 3;
  printf("  blog4() := %f\n", *parr);


  struct { wchar_t *name; float amount; } label, *plabel;
  label.amount = 49.95;
  plabel = &label;
  plabel->name = "Bill Joy ★";
  printf("  blog4() [name := %s] [amount := %f]\n", plabel->name, plabel->amount);

}




int main() {
//  list = g_list_append(list, "a");
//  list = g_list_append(list, "b");
//  list = g_list_append(list, "c");
//
//  for ( ; list != NULL; list = list->next) {
//    printf("%s\n", (char*)list->data);
//  }
//
//  printf("\nreturn of the mack%i\n", get_rand());
//
//  print_time();

  // open syscall
  //file_io_fun();
  
  // syslog API
  //logit("A tree falls in the forest");


  // bens logger
  //print_log(LOG_WARNING, "where be a wookie when you need one");



  //blog1(); //typedefs
  //blog2(); //basic types
  //blog3(); //strings
  blog4(); //memory operands


  // little random demo
  // time_t rawtime;
  // time(&rawtime);
  // struct tm* da_time = localtime(&rawtime);
  // srand(da_time->tm_sec);
  // printf("rand() = %i\n", rand());

  return 0;
}
