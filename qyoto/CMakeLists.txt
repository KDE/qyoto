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

# find 'gmcs'
MESSAGE (STATUS "Looking for gmcs")
FIND_PROGRAM (GMCS_PATH gmcs)
IF (NOT GMCS_PATH)
	MESSAGE (STATUS "Looking for gmcs - not found")
	MESSAGE (FATAL_ERROR "gmcs was not found on your system")
ELSE (NOT GMCS_PATH)
	MESSAGE (STATUS "Looking for gmcs - found - ${GMCS_PATH}")
ENDIF (NOT GMCS_PATH)

INCLUDE_DIRECTORIES (${QT_INCLUDES})
ADD_LIBRARY (qyoto SHARED qyoto.cpp handlers.cpp)
TARGET_LINK_LIBRARIES (qyoto smokeqt ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

ADD_CUSTOM_TARGET (qt-dotnet ALL ${GMCS_PATH} -unsafe -warn:0 -out:qt-dotnet.dll -target:library SmokeInvocation.cs Qyoto.cs core/*.cs gui/*.cs network/*.cs sql/*.cs xml/*.cs svg/*.cs opengl/*.cs qdbus/*.cs)

ADD_DEPENDENCIES (qt-dotnet qyoto)
