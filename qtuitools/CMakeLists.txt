PROJECT(qtuitools-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/qtuitools.cpp src/qtuitoolshandlers.cpp)

SET(SRC_CS src/QtUiTools.cs
	src/AssemblyInfo.cs
	qtuitools/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(qtuitools-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(qtuitools-sharp smokeqt smokeqtuitools qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qtuitools "${SRC_CS}" ALL)
ADD_DEPENDENCIES(qtuitools qt-dotnet qtuitools-sharp smokeqtuitools)

INSTALL(TARGETS qtuitools-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(qtuitools)
