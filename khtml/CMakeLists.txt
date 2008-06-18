PROJECT(khtml-sharp)

IF (NOT KDE4_FOUND)
	FIND_PACKAGE(KDE4 REQUIRED)
ENDIF (NOT KDE4_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/khtml.cpp src/khtmlhandlers.cpp)

SET(SRC_CS src/AssemblyInfo.cs 
 src/KHTML.cs 
khtml/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(khtml-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(khtml-sharp smokeqt smokekde smokekhtml qyotoshared ${KHTML_LIBS})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(khtml "${SRC_CS}" ALL)
ADD_DEPENDENCIES(khtml-sharp smokekhtml)

INSTALL(TARGETS khtml-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(khtml)
