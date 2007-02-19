PROJECT (kimono)

# source files
SET(SRC_CPP qyoto.cpp
	handlers.cpp)

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/SmokeInvocation.cs
	${CMAKE_CURRENT_SOURCE_DIR}/SmokeMarshallers.cs
	${CMAKE_CURRENT_SOURCE_DIR}/Qyoto.cs
	${CMAKE_CURRENT_SOURCE_DIR}/QyotoMetaData.cs
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

# find the SMOKE library
MESSAGE (STATUS "Looking for SMOKE library")
FIND_LIBRARY (SMOKE_PATH smokeqt)
IF (NOT SMOKE_PATH)
	MESSAGE (STATUS "Looking for SMOKE library - not found")
	MESSAGE (FATAL_ERROR "The SMOKE Library was not found on your system")
ELSE (NOT SMOKE_PATH)
	MESSAGE (STATUS "Looking for SMOKE library - found - ${SMOKE_PATH}")
ENDIF (NOT SMOKE_PATH)

# find 'gmcs'
MESSAGE (STATUS "Looking for gmcs")
FIND_PROGRAM (GMCS_PATH gmcs)
IF (NOT GMCS_PATH)
	MESSAGE (STATUS "Looking for gmcs - not found")
	MESSAGE (FATAL_ERROR "gmcs was not found on your system")
ELSE (NOT GMCS_PATH)
	MESSAGE (STATUS "Looking for gmcs - found - ${GMCS_PATH}")
ENDIF (NOT GMCS_PATH)

SET( UICS_PATH ${CMAKE_CURRENT_SOURCE_DIR}/uics/uics )
SET( CSRCC_PATH ${CMAKE_CURRENT_SOURCE_DIR}/tools/csrcc/csrcc )

INCLUDE_DIRECTORIES (${QT_INCLUDES})
ADD_LIBRARY (qyoto SHARED ${SRC_CPP})
TARGET_LINK_LIBRARIES (qyoto smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

ADD_CUSTOM_TARGET (qt-dotnet ALL ${GMCS_PATH} -unsafe -warn:0 -out:qt-dotnet.dll -target:library ${SRC_CS}
	COMMENT "Building qt-dotnet.dll")

ADD_DEPENDENCIES (qt-dotnet qyoto)

ADD_SUBDIRECTORY(uics)
ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples)
