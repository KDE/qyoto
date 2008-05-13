PROJECT (qyoto)

# find Qt4
IF (NOT QT4_FOUND)
	FIND_PACKAGE (Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)
INCLUDE (CSharpMacros)

# source files
SET(SRC_CPP_SHARED src/emitsignal.cpp
	src/invokeslot.cpp
	src/methodcall.cpp
	src/methodreturnvalue.cpp
	src/readproperty.cpp
	src/signalreturnvalue.cpp
	src/slotreturnvalue.cpp
	src/virtualmethodcall.cpp
	src/virtualmethodreturnvalue.cpp
	src/writeproperty.cpp
	src/qyotosmokebinding.cpp
	src/handlers.cpp
	src/qyotoshared.cpp)

SET(SRC_CPP src/qyoto.cpp)

SET(SRC_CS src/SmokeInvocation.cs
	src/SmokeMarshallers.cs
	src/Qyoto.cs
	src/QyotoMetaData.cs
	src/AssemblyInfo.cs
	core/*.cs
	gui/*.cs
	network/*.cs
	sql/*.cs
	xml/*.cs
	svg/*.cs
	opengl/*.cs
	uitools/*.cs
	qdbus/*.cs)

SET( UICS_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/uics/uics )
SET( CSRCC_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/csrcc/csrcc )

INCLUDE_DIRECTORIES (${QT_INCLUDES} ${CMAKE_SOURCE_DIR}/smoke ${CMAKE_SOURCE_DIR}/smoke/qt ${CMAKE_CURRENT_SOURCE_DIR}/src)
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})

ADD_LIBRARY (qyotoshared SHARED ${SRC_CPP_SHARED})
TARGET_LINK_LIBRARIES (qyotoshared smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

ADD_LIBRARY (qyoto MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES (qyoto qyotoshared smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -debug -define:DEBUG -unsafe -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qt-dotnet "${SRC_CS}" ALL)

ADD_DEPENDENCIES (qt-dotnet qyoto)

INSTALL(TARGETS qyoto LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL(TARGETS qyotoshared LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL(FILES src/emitsignal.h src/invokeslot.h src/marshall.h src/methodcall.h src/methodreturnvalue.h
src/qyoto.h src/qyotosmokebinding.h src/readproperty.h src/signalreturnvalue.h src/slotreturnvalue.h
src/smokeqyoto.h src/virtualmethodcall.h src/virtualmethodreturnvalue.h src/writeproperty.h DESTINATION include/qyoto)
INSTALL_GAC(qt-dotnet)

ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples)
