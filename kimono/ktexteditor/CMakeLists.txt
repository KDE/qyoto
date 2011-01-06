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

LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(ktexteditor-sharp SHARED ${SRC_CPP})
ADD_DEPENDENCIES(ktexteditor-sharp ${SMOKE_KTEXTEDITOR_LIBRARY})
TARGET_LINK_LIBRARIES(ktexteditor-sharp ${QT_QTCORE_LIBRARY}
    ${KDE4_KTEXTEDITOR_LIBS}
    ${SMOKE_KTEXTEDITOR_LIBRARY}
    ${SMOKE_BASE_LIBRARY}
    ${QYOTO_LIBRARY}
)

# cmake doesn't like the assembly to be called 'ktexteditor', but why?
CSHARP_ADD_LIBRARY(ktexteditor-dotnet "${SRC_CS}" REFERENCES ${QYOTO_ASSEMBLY} kde-dotnet COMPILE_FLAGS /warn:0 /keyfile:${QYOTO_KEYFILE})
ADD_DEPENDENCIES(ktexteditor-dotnet kde-dotnet)
ADD_DEPENDENCIES(ktexteditor-sharp smokektexteditor qyoto)

INSTALL(TARGETS ktexteditor-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(ktexteditor-dotnet DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)

add_subdirectory(examples EXCLUDE_FROM_ALL)
