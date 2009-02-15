PROJECT(qimageblitz-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

IF (NOT QIMAGEBLITZ_FOUND)
	FIND_PACKAGE(QImageBlitz REQUIRED)
ENDIF (NOT QIMAGEBLITZ_FOUND)

SET(SRC_CPP src/blitz.cpp)

SET(SRC_CS src/BlitzBinding.cs
	src/AssemblyInfo.cs
	qimageblitz/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES} ${QIMAGEBLITZ_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(qimageblitz-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(qimageblitz-sharp smokeqt smokeqimageblitz qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY}
    ${QIMAGEBLITZ_LIBRARIES})

SET(CS_FLAGS /r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll /warn:0 /keyfile:${KEYFILE})
ADD_CS_LIBRARY(qimageblitz "${SRC_CS}" ALL)
ADD_DEPENDENCIES(qimageblitz qt-dotnet qimageblitz-sharp smokeqimageblitz)

INSTALL(TARGETS qimageblitz-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(qimageblitz)
