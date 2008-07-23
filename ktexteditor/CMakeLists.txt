PROJECT(ktexteditor-sharp)

IF (NOT KDE4_FOUND)
	FIND_PACKAGE(KDE4 REQUIRED)
ENDIF (NOT KDE4_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/ktexteditor.cpp src/ktexteditorhandlers.cpp)

SET(SRC_CS src/AssemblyInfo.cs 
 src/KTextEditor.cs 
ktexteditor/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(ktexteditor-sharp MODULE ${SRC_CPP})
ADD_DEPENDENCIES(ktexteditor-sharp smokektexteditor)
TARGET_LINK_LIBRARIES(ktexteditor-sharp ${QT_QTCORE_LIBRARY} smokeqt smokekde smokektexteditor qyotoshared)

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
# cmake doesn't like the assembly to be called 'ktexteditor', but why?
ADD_CS_LIBRARY(ktexteditor-dotnet "${SRC_CS}" ALL)
ADD_DEPENDENCIES(ktexteditor-dotnet kde-dotnet)
ADD_DEPENDENCIES(ktexteditor-sharp smokektexteditor qyotoshared)

INSTALL(TARGETS ktexteditor-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(ktexteditor-dotnet)
