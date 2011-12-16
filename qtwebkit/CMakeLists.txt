PROJECT(qtwebkit-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/qtwebkit.cpp src/qtwebkithandlers.cpp)

SET(SRC_CS_IN src/QtWebKit.cs
	src/AssemblyInfo.cs
	qtwebkit/*.cs)

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
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(qtwebkit-sharp SHARED ${SRC_CPP})
TARGET_LINK_LIBRARIES(qtwebkit-sharp ${SMOKE_QTWEBKIT_LIBRARY} qyoto ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${QT_QTWEBKIT_LIBRARY})

CSHARP_ADD_LIBRARY(qtwebkit "${SRC_CS}" REFERENCES qt-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
SET_PROPERTY(TARGET qtwebkit PROPERTY pkg-config_template_basename ${PROJECT_NAME})
ADD_DEPENDENCIES(qtwebkit qt-dotnet qtwebkit-sharp ${SMOKE_QTWEBKIT_LIBRARY})

install(TARGETS qtwebkit-sharp
    LIBRARY DESTINATION ${LIB_INSTALL_DIR}
    ARCHIVE DESTINATION ${LIB_INSTALL_DIR}
    RUNTIME DESTINATION bin)
if (WIN32)
    # Get rid of the "lib" prefix on archives/DLLs in Windows.
    set_target_properties(qtwebkit-sharp PROPERTIES PREFIX "" IMPORT_PREFIX "")
endif (WIN32)
INSTALL_ASSEMBLY(qtwebkit DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)
