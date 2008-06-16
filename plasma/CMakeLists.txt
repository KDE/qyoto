PROJECT(plasma-sharp)

FIND_PACKAGE(Plasma REQUIRED)

IF (NOT PLASMA_FOUND)
	FIND_PACKAGE(Plasma REQUIRED)
ENDIF (NOT PLASMA_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/plasma.cpp src/plasmahandlers.cpp)

SET(SRC_CS src/AssemblyInfo.cs 
 src/Plasma.cs 
plasma/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(plasma-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(plasma-sharp smokeqt smokekde smokeplasma qyotoshared ${PLASMA_LIBS})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(plasma "${SRC_CS}" ALL)
ADD_DEPENDENCIES(plasma-sharp smokeplasma)

INSTALL(TARGETS plasma-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(plasma)
