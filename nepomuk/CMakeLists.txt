PROJECT(nepomuk-sharp)

IF (NOT NEPOMUK_FOUND)
	FIND_PACKAGE(Nepomuk REQUIRED)
ENDIF (NOT NEPOMUK_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

SET(SRC_CPP src/nepomuk.cpp src/nepomukhandlers.cpp)

SET(SRC_CS src/Nepomuk.cs
	src/AssemblyInfo.cs
	nepomuk/*.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(nepomuk-sharp MODULE ${SRC_CPP})
TARGET_LINK_LIBRARIES(nepomuk-sharp ${NEPOMUK_LIBRARIES} smokenepomuk qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

CSHARP_ADD_LIBRARY(nepomuk-dll "${SRC_CS}" REFERENCES qt-dotnet soprano COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
ADD_DEPENDENCIES(nepomuk-dll qt-dotnet soprano nepomuk-sharp smokenepomuk)

INSTALL(TARGETS nepomuk-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(nepomuk-dll DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)
