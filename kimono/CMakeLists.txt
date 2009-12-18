PROJECT(kimono)

find_package(PkgConfig)

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/src/Kimono.cs
	${CMAKE_CURRENT_SOURCE_DIR}/src/AssemblyInfo.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kde/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kio/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kparts/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/sonnet/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kns/*.cs)

SET(SRC_KIMONO src/kimono.cpp src/kdehandlers.cpp)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
KDE4_ADD_LIBRARY(kimono MODULE ${SRC_KIMONO})
TARGET_LINK_LIBRARIES(kimono qyotoshared
                      smokekdecore smokekdeui smokekio smokekparts smokekfile smokeknewstuff2 smokeknewstuff3 smokekutils
                      ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY}
                      ${KDE4_KDECORE_LIBS} ${KDE4_KIO_LIBS})

# write FindPackage modules for these
pkg_search_module(MONO mono)
pkg_search_module(GLIB2 glib-2.0)

# if libmono-dev is not installed, then MONO_INCLUDES is not defined and compiling
# the kimonopluginfactory would fail. So, just disable kimonopluginfactory if the
# MONO_INCLUDES is empty and provide some feedback to the user about it.
IF (MONO_FOUND)
    SET(SRC_FACTORY src/kimonopluginfactory.cpp)
    LINK_DIRECTORIES(${MONO_LIBRARY_DIRS} ${GLIB2_LIBRARY_DIRS})
    INCLUDE_DIRECTORIES(${MONO_INCLUDE_DIRS} ${GLIB2_INCLUDE_DIRS})
    ADD_DEFINITIONS(${GLIB2_CFLAGS} ${MONO_CFLAGS})
    KDE4_ADD_PLUGIN(kimonopluginfactory ${SRC_FACTORY})
    TARGET_LINK_LIBRARIES(kimonopluginfactory ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${KDE4_KDECORE_LIBS} ${KDE4_KIO_LIBS} qyotoshared smokeqtcore smokeqtgui ${MONO_LIBRARIES})
    INSTALL(TARGETS kimonopluginfactory DESTINATION ${PLUGIN_INSTALL_DIR})
ELSE (MONO_FOUND)
    MESSAGE(STATUS "Mono not found. kimonopluginfactory will not be compiled.")
ENDIF (MONO_FOUND)

CSHARP_ADD_LIBRARY(kde-dotnet "${SRC_CS}" REFERENCES qt-dotnet COMPILE_FLAGS /warn:0 /keyfile:${KEYFILE})
ADD_DEPENDENCIES (kde-dotnet qt-dotnet kimono)

INSTALL(TARGETS kimono LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(kde-dotnet DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)

add_subdirectory(tutorials EXCLUDE_FROM_ALL)
add_subdirectory(examples EXCLUDE_FROM_ALL)
