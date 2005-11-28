all: doit.exe libqyoto.so

doit.exe:	doit.cs QFont.cs SmokeInvocation.cs
	mcs -unsafe -o doit.exe doit.cs QFont.cs SmokeInvocation.cs

hello.exe: Hello.cs SmokeInvocation.cs
	mcs -unsafe -out:hello.exe Hello.cs SmokeInvocation.cs qt3qyoto/*.cs


#libqyoto.so:	qyoto.cpp handlers.cpp
#	gcc -shared -o libqyoto.so \
#	-I/home/duke/src/kde/kde/trunk/KDE/kdebindings/smoke \
#	-I/opt/kde4/include -I/opt/kde4/include/QtCore \
#	-I/opt/kde4/include/QtGui \
#	-L/opt/kde4/lib -lQtCore -lQtGui -lsmokeqt qyoto.cpp handlers.cpp

libqyoto.so:	qt3qyoto.cpp qt3handlers.cpp
	gcc -shared -o libqyoto.so \
	-I/home/duke/src/kde/kde/branches/KDE/3.5/kdebindings/smoke \
	-I/opt/kde3/include \
	-L/opt/kde3/lib -lqt-mt -lsmokeqt qt3qyoto.cpp qt3handlers.cpp

tryit:	qyoto.cpp handlers.cpp
	gcc -shared -o tryit -I/home/duke/src/kde/kde/trunk/kdebindings/smoke -I/opt/kde4/include \
	-L/opt/kde4/lib -lqt-mt -lsmokeqt qyoto.cpp handlers.cpp main.cpp
