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
TARGET_LINK_LIBRARIES(ktexteditor-sharp ${QT_QTCORE_LIBRARY} smokektexteditor qyotoshared)

# cmake doesn't like the assembly to be called 'ktexteditor', but why?
CSHARP_ADD_LIBRARY(ktexteditor-dotnet "${SRC_CS}" REFERENCES qt-dotnet kde-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
ADD_DEPENDENCIES(ktexteditor-dotnet kde-dotnet)
ADD_DEPENDENCIES(ktexteditor-sharp smokektexteditor qyotoshared)

INSTALL(TARGETS ktexteditor-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(ktexteditor-dotnet DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)

add_subdirectory(examples EXCLUDE_FROM_ALL)
