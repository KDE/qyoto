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
TARGET_LINK_LIBRARIES(qtscript-sharp smokeqt smokeqtscript qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qtscript "${SRC_CS}" ALL)
ADD_DEPENDENCIES(qtscript qt-dotnet qtscript-sharp smokeqtscript)

INSTALL(TARGETS qtscript-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(qtscript)
INSTALL(FILES ${PROJECT_NAME}.pc DESTINATION ${LIB_INSTALL_DIR}/pkgconfig )
