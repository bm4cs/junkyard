#ifndef INCLUDE_LOGGER_H_
#define INCLUDE_LOGGER_H_

#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <stdarg.h>
#include <time.h>

#define COW_LOG_CRITICAL 0
#define COW_LOG_ERROR    1
#define COW_LOG_WARNING  2
#define COW_LOG_INFO     3
#define COW_LOG_INVALID  4

static 
char *log_tags[2][5] = { { "[CRITICAL] ",
               "[ERROR]    ",
               "[WARNING]  ",
               "[INFO]     ", 
               "[INVALID LOG LEVEL] "},
           {   "[!] ",
         "[*] ",
         "[-] ",
         "[+] ",
         "[~] " }};

#define COW_LOG_VERBOSE 0
#define COW_LOG_CONCISE 1

extern FILE *set_log_file(char *);
extern int get_log_mode();
extern void set_log_mode(int);

#define print_log(level, ...) do {        \
        time_t _clk = time(NULL); \
        _print_log(level, __FILE__, __func__, ctime(&_clk), __LINE__, __VA_ARGS__); \
           } while (0)

extern void _print_log(int, char *, const char *, char*, int, char *, ...);


#endif /* INCLUDE_LOGGER_H_ */
