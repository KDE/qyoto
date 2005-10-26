all: doit.exe libqyoto.so

doit.exe:	doit.cs QFont.cs SmokeInvocation.cs
	mcs --unsafe -o doit.exe doit.cs QFont.cs SmokeInvocation.cs


libqyoto.so:	qyoto.cpp handlers.cpp
	gcc -shared -o libqyoto.so \
	-I/home/duke/src/kde/kde/trunk/KDE/kdebindings/smoke \
	-I/opt/kde4/include -I/opt/kde4/include/QtCore \
	-I/opt/kde4/include/QtGui \
	-L/opt/kde4/lib -lQtCore -lQtGui -lsmokeqt qyoto.cpp handlers.cpp

tryit:	qyoto.cpp handlers.cpp
	gcc -shared -o tryit -I/home/duke/src/kde/kde/trunk/kdebindings/smoke -I/opt/kde4/include \
	-L/opt/kde4/lib -lqt-mt -lsmokeqt qyoto.cpp handlers.cpp main.cpp
