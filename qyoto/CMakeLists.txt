PROJECT (qyoto)

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

SET(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)

# find Qt4
IF (NOT QT4_FOUND)
	FIND_PACKAGE (Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET( UICS_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/uics/uics )
SET( CSRCC_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/csrcc/csrcc )

INCLUDE_DIRECTORIES (${QT_INCLUDES} ${CMAKE_SOURCE_DIR}/smoke)
ADD_LIBRARY (qyoto MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES (qyoto smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -debug -define:DEBUG -unsafe -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qt-dotnet "${SRC_CS}" ALL)

ADD_DEPENDENCIES (qt-dotnet qyoto)

INSTALL(TARGETS qyoto LIBRARY DESTINATION lib)
INSTALL_GAC(qt-dotnet)

ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples)
