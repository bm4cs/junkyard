cmake_minimum_required(VERSION 3.3)
project(hellobrowser)




set(MY_VAR "hello")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -g -std=gnu11 -O0")
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY "${hellobrowser_SOURCE_DIR}/target")
#set(SOURCE_FILES
#    hellobrowser.c)

file(GLOB_RECURSE SOURCE_FILES "*.c")

add_executable(hellobrowser ${SOURCE_FILES})

find_library(MICROHTTPD_LIBRARY NAMES libmicrohttpd.so
        PATHS
        /usr/lib
        /usr/lib64
        /usr/local/lib
        /usr/local/lib64)

#if (MICROHTTPD_LIBRARY)
#    MESSAGE( "clever girl ${MICROHTTPD_LIBRARY}")
#endif (MICROHTTPD_LIBRARY)

target_link_libraries(hellobrowser ${MICROHTTPD_LIBRARY})