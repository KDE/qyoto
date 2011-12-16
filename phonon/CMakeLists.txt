PROJECT(phonon-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

IF (NOT PHONON_FOUND)
	FIND_PACKAGE(Phonon REQUIRED)
ENDIF (NOT PHONON_FOUND)

SET(SRC_CPP src/phonon.cpp src/phononhandlers.cpp)

SET(SRC_CS_IN src/PhononBinding.cs
	src/AssemblyInfo.cs
	phonon/*.cs)

if (WIN32)
    # Microsoft's .NET compiler needs backslashes.  Two are needed
    # because CMake uses backslash as an escape character.
    foreach (arg ${SRC_CS_IN})
        string (REPLACE "/" "\\\\" arg ${arg})
        SET(SRC_CS ${SRC_CS} ${arg})
    endforeach (arg ${SRC_CS_IN})
else (WIN32)
    SET (SRC_CS ${SRC_CS_IN})
endif (WIN32)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/generator 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES} ${PHONON_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(phonon-sharp SHARED ${SRC_CPP})
TARGET_LINK_LIBRARIES(phonon-sharp ${SMOKE_PHONON_LIBRARY} qyoto ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${PHONON_LIBS})

CSHARP_ADD_LIBRARY(phonon "${SRC_CS}" REFERENCES qt-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
ADD_DEPENDENCIES(phonon qt-dotnet phonon-sharp ${SMOKE_PHONON_LIBRARY})

install(TARGETS phonon-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR}
    ARCHIVE DESTINATION ${LIB_INSTALL_DIR}
    RUNTIME DESTINATION bin)
if (WIN32)
    # Get rid of the "lib" prefix on archives/DLLs in Windows.
    set_target_properties(phonon-sharp PROPERTIES PREFIX "" IMPORT_PREFIX "")
endif (WIN32)
INSTALL_ASSEMBLY(phonon DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)
