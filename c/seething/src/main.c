

#include "allheads.h"



// https://developer.gnome.org/glib/stable/index.html



GList *list;

int get_rand() {
	srand(time(NULL));
	return rand() % 100;
	return 1;
}

void print_time() {

//	tm foo;

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

//	nr = read(fd, buf, sizeof(buf));
//	if (nr == -1) {
//
//		return;
//	}

	printf("read() := %s\n", buf);

}


int main() {
//	list = g_list_append(list, "a");
//	list = g_list_append(list, "b");
//	list = g_list_append(list, "c");
//
//	for ( ; list != NULL; list = list->next) {
//		printf("%s\n", (char*)list->data);
//	}
//
//	printf("\nreturn of the mack%i\n", get_rand());
//
//	print_time();

	file_io_fun();

	return 0;
}
