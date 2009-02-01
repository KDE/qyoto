PROJECT(phonon-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

IF (NOT PHONON_FOUND)
	FIND_PACKAGE(Phonon REQUIRED)
ENDIF (NOT PHONON_FOUND)

SET(SRC_CPP src/phonon.cpp src/phononhandlers.cpp)

SET(SRC_CS src/PhononBinding.cs
	src/AssemblyInfo.cs
	phonon/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES} ${PHONON_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(phonon-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(phonon-sharp smokeqt smokephonon qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${PHONON_LIBS})

SET(CS_FLAGS /r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll /warn:0 /keyfile:${KEYFILE})
ADD_CS_LIBRARY(phonon "${SRC_CS}" ALL)
ADD_DEPENDENCIES(phonon qt-dotnet phonon-sharp smokephonon)

INSTALL(TARGETS phonon-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(phonon)
