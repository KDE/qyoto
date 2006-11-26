PROJECT (kimono)

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

# find 'mcs'
MESSAGE (STATUS "Looking for mcs")
FIND_PROGRAM (MCS_PATH mcs)
IF (NOT MCS_PATH)
	MESSAGE (STATUS "Looking for mcs - not found")
	MESSAGE (FATAL_ERROR "mcs was not found on your system")
ELSE (NOT MCS_PATH)
	MESSAGE (STATUS "Looking for mcs - found - ${MCS_PATH}")
ENDIF (NOT MCS_PATH)

INCLUDE_DIRECTORIES (${QT_INCLUDES})
ADD_LIBRARY (qyoto SHARED qyoto.cpp handlers.cpp)
TARGET_LINK_LIBRARIES (qyoto ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

ADD_CUSTOM_TARGET (qt-dotnet ALL ${MCS_PATH} -unsafe -warn:0 -out:qt-dotnet.dll -target:library SmokeInvocation.cs Qyoto.cs qyoto/*.cs qdbus/*.cs)

ADD_DEPENDENCIES (qt-dotnet qyoto)