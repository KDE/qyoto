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
include_directories( ${KDE4_INCLUDE_DIR}/akonadi )

LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(akonadi-sharp SHARED ${SRC_CPP})
TARGET_LINK_LIBRARIES(akonadi-sharp 
    smokeakonadi
    qyoto 
    ${KDEPIMLIBS_AKONADI_LIBS} 
    ${KDEPIMLIBS_AKONADI_KMIME_LIBS}
    ${QT_QTCORE_LIBRARY} 
    ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
CSHARP_ADD_LIBRARY(akonadi "${SRC_CS}" REFERENCES qt-dotnet kde-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
ADD_DEPENDENCIES(akonadi kde-dotnet akonadi-sharp smokeakonadi)

INSTALL(TARGETS akonadi-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(akonadi DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)
