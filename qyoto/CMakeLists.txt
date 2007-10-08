PROJECT (qyoto)

# find Qt4
IF (NOT QT4_FOUND)
	FIND_PACKAGE (Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)
FIND_PACKAGE (QScintilla)
INCLUDE (CSharpMacros)

# source files
SET(SRC_CPP src/qyoto.cpp
	src/handlers.cpp)

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
	
SET(SRC_SCINTILLA src/AssemblyInfoQScintilla2.cs
	qsci/*.cs)

SET(KEYFILE ${CMAKE_SOURCE_DIR}/csharp/qyoto/key.snk)

SET( UICS_EXECUTABLE ${CMAKE_BINARY_DIR}/csharp/qyoto/tools/uics/uics )
SET( CSRCC_EXECUTABLE ${CMAKE_BINARY_DIR}/csharp/qyoto/tools/csrcc/csrcc )

INCLUDE_DIRECTORIES (${QT_INCLUDES} ${CMAKE_SOURCE_DIR}/smoke)
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY (qyoto MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES (qyoto smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -debug -define:DEBUG -unsafe -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qt-dotnet "${SRC_CS}" ALL)

ADD_DEPENDENCIES (qt-dotnet qyoto)

IF (QSCINTILLA_FOUND)
	MESSAGE (STATUS "Found QScintilla2, compiling Qyoto with QScintilla2 support (SMOKE has to be built with support for it, too)")
	SET(CS_FLAGS -debug -define:DEBUG -warn:0 -keyfile:${KEYFILE} -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll)
	ADD_CS_LIBRARY(qscintilla "${SRC_SCINTILLA}" ALL)
	ADD_DEPENDENCIES (qscintilla qt-dotnet)
	INSTALL_GAC(qscintilla)
ENDIF (QSCINTILLA_FOUND)

INSTALL(TARGETS qyoto LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(qt-dotnet)

ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples)
