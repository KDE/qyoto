PROJECT(soprano-sharp)

FIND_PACKAGE(Soprano REQUIRED)

IF (NOT SOPRANO_FOUND)
	FIND_PACKAGE(Soprano REQUIRED)
ENDIF (NOT SOPRANO_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/soprano.cpp src/sopranohandlers.cpp)

SET(SRC_CS src/AssemblyInfo.cs 
 src/Soprano.cs 
soprano/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(soprano-sharp MODULE ${SRC_CPP})
ADD_DEPENDENCIES(soprano-sharp smokesoprano)
TARGET_LINK_LIBRARIES(soprano-sharp smokeqt smokesoprano qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(soprano "${SRC_CS}" ALL)

INSTALL(TARGETS soprano-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(soprano)
