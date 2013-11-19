#
# Evil RTSP Server
#
# Serves malicious RTSP resposes based on output files in a Peach fault
# iteration directory.
#
# Usage: python EvilRtspServer.py target_directory
#
#   target_directory       - Directory containing the output information from a
#                            saved Peach Fault iteration.
#

import sys
import socket
import os

def collectResponses(sourceDirectory):
    responses = []
    responseFiles = []

    for pathname in os.listdir(sourceDirectory):
        if pathname.endswith(".txt") and (pathname.find("_Output_") != -1):
            responseFiles.append(pathname)

    for responseFile in responseFiles:
        fullPath = os.path.join(sourceDirectory, responseFile)
        responses.append(open(fullPath, 'rb').read(-1))

    return responses

def listenAndRespond(connection, response):
    while True:
        data = connection.recv(4096)
        print(data)
        if data.endswith("\r\n\r\n") or data == "":
            break

    print(response)
    connection.sendall(response)

def main():
    if (len(sys.argv)) != 2 or not os.path.isdir(sys.argv[1]):
        print("Usage: EvilRtspServer.py target_directory")
        print("")
        print("Specify a directory containing a Peach iteration to replay.")
        exit(0)

    HOST = '127.0.0.1'
    PORT = 554
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.bind((HOST, PORT))
    s.listen(1)
    conn = None

    while True:
        try:
            conn, addr = s.accept()
            print 'Connection from %s:%d' % addr

            for response in collectResponses(sys.argv[1]):
                listenAndRespond(conn, response)
        except:
            pass
        finally:
            if conn is not None:
                conn.close()
                print 'Connection from %s:%d closed' % addr

if __name__ == "__main__":
    main()