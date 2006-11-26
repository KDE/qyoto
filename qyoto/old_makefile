all: doit.exe libqyoto.so

doit.exe:	doit.cs qyoto/QFont.cs SmokeInvocation.cs
	mcs -unsafe -debug -o doit.exe doit.cs qyoto/QFont.cs SmokeInvocation.cs

hello.exe: Hello.cs SmokeInvocation.cs
	mcs -unsafe -debug -out:hello.exe Hello.cs SmokeInvocation.cs qyoto/*.cs dbus/*.cs

qstringtest.exe: QStringTest.cs SmokeInvocation.cs
	mcs -unsafe -debug -out:qstringtest.exe QStringTest.cs SmokeInvocation.cs qyoto/*.cs

t1.exe: t1.cs SmokeInvocation.cs
	mcs -unsafe -debug -out:t1.exe t1.cs SmokeInvocation.cs qyoto/*.cs

qyoto.dll: SmokeInvocation.cs
	mcs -unsafe -debug -out:qyoto.dll -target:library SmokeInvocation.cs qyoto/*.cs dbus/*.cs

libqyoto.so:	qyoto.cpp handlers.cpp
	gcc -shared -o libqyoto.so \
	-I/home/sbe/devel/svn/kde/trunk/KDE/kdebindings/smoke \
	-I/usr/include/qt4/ -I/usr/include/qt4/QtCore \
	-lQtCore -lQtGui -lsmokeqt qyoto.cpp handlers.cpp

#libqyoto.so:	qt3qyoto.cpp qt3handlers.cpp
#	gcc -g -shared -o libqyoto.so \
#	-I/home/duke/src/kde/kde/branches/KDE/3.5/kdebindings/smoke \
#	-I/opt/kde3/include \
#	-L/opt/kde3/lib -lqt-mt -lsmokeqt qt3qyoto.cpp qt3handlers.cpp

tryit:	qyoto.cpp handlers.cpp main.cpp
	gcc -g -o tryit -I/home/sbe/devel/svn/kde/trunk/kdebindings/smoke -I/usr/include/qt4 \
	-L/usr/lib -lQtCore -lsmokeqt qyoto.cpp handlers.cpp main.cpp
