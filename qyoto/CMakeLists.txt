PROJECT (kimono)

# source files
SET(SRC_CPP src/qyoto.cpp
	src/handlers.cpp)

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/src/SmokeInvocation.cs
	${CMAKE_CURRENT_SOURCE_DIR}/src/SmokeMarshallers.cs
	${CMAKE_CURRENT_SOURCE_DIR}/src/Qyoto.cs
	${CMAKE_CURRENT_SOURCE_DIR}/src/QyotoMetaData.cs
	${CMAKE_CURRENT_SOURCE_DIR}/core/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/gui/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/network/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/sql/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/xml/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/svg/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/opengl/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/qdbus/*.cs)

# find Qt4
FIND_PACKAGE (Qt4 REQUIRED)

SET( UICS_PATH ${CMAKE_CURRENT_BINARY_DIR}/tools/uics/uics )
SET( CSRCC_PATH ${CMAKE_CURRENT_BINARY_DIR}/tools/csrcc/csrcc )

INCLUDE_DIRECTORIES (${QT_INCLUDES} ${CMAKE_SOURCE_DIR}/smoke)
ADD_LIBRARY (qyoto MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES (qyoto smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

ADD_CUSTOM_TARGET (qt-dotnet ALL ${GMCS_PATH} -debug -define:DEBUG -unsafe -warn:0 -out:qt-dotnet.dll -target:library ${SRC_CS}
	COMMENT "Building qt-dotnet.dll")

ADD_DEPENDENCIES (qt-dotnet qyoto)

ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples)
