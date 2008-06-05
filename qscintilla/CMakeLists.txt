PROJECT(qscintilla-sharp)

IF (NOT QSCINTILLA_FOUND)
	FIND_PACKAGE(QScintilla REQUIRED)
ENDIF (NOT QSCINTILLA_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/qscintilla.cpp)

SET(SRC_CS src/SmokeInvocationQsci.cs
	src/AssemblyInfo.cs
	qsci/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke ${CMAKE_SOURCE_DIR}/smoke/qt ${CMAKE_SOURCE_DIR}/smoke/qsci
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(qscintilla-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(qscintilla-sharp smokeqt smokeqsci qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(qscintilla "${SRC_CS}" ALL)
ADD_DEPENDENCIES(qscintilla-sharp smokeqsci)

INSTALL(TARGETS qscintilla-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(qscintilla)
