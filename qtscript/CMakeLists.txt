PROJECT(qtscript-sharp)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/qtscript.cpp
            src/qtscripthandlers.cpp)

SET(SRC_CS src/QtScript.cs
	src/AssemblyInfo.cs
	qtscript/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(qtscript-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(qtscript-sharp smokeqtscript qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

CSHARP_ADD_LIBRARY(qtscript "${SRC_CS}" REFERENCES qt-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
SET_PROPERTY(TARGET qtscript PROPERTY pkg-config_template_basename ${PROJECT_NAME})
ADD_DEPENDENCIES(qtscript qt-dotnet qtscript-sharp smokeqtscript)

INSTALL(TARGETS qtscript-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(qtscript DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)
