PROJECT(akonadi-sharp)

IF (NOT AKONADI_FOUND)
	FIND_PACKAGE(Akonadi REQUIRED)
ENDIF (NOT AKONADI_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/akonadi.cpp src/akonadihandlers.cpp)

SET(SRC_CS src/Akonadi.cs
	src/AssemblyInfo.cs
	akonadi/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(akonadi-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(akonadi-sharp smokeqt smokeakonadi qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(akonadi "${SRC_CS}" ALL)
ADD_DEPENDENCIES(akonadi-sharp smokeakonadi)

INSTALL(TARGETS akonadi-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(akonadi)
