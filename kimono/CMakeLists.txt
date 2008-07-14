PROJECT(kimono)

INCLUDE(UsePkgConfig)

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
ADD_DEPENDENCIES(kimono smokekde)
TARGET_LINK_LIBRARIES(kimono smokekde qyotoshared ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY})

# write FindPackage modules for these
PKGCONFIG(mono MONO_INCLUDES MONO_LINK_DIR MONO_LINK_FLAGS MONO_CFLAGS)
PKGCONFIG(glib-2.0 GLIB_INCLUDES GLIB_LINK_DIR GLIB_LINK_FLAGS GLIB_CFLAGS)

# if libmono-dev is not installed, then MONO_INCLUDES is not defined and compiling
# the kimonopluginfactory would fail. So, just disable kimonopluginfactory if the
# MONO_INCLUDES is empty and provide some feedback to the user about it.
IF (MONO_INCLUDES)
    SET(SRC_FACTORY src/kimonopluginfactory.cpp)
    LINK_DIRECTORIES(${MONO_LINK_DIR} ${GLIB_LINK_DIR})
    INCLUDE_DIRECTORIES(${MONO_INCLUDES} ${GLIB_INCLUDES})
    ADD_DEFINITIONS(${GLIB_CFLAGS} ${MONO_CFLAGS})
    KDE4_ADD_PLUGIN(kimonopluginfactory ${SRC_FACTORY})
    TARGET_LINK_LIBRARIES(kimonopluginfactory ${KDE4_KDECORE_LIBS} qyotoshared ${MONO_LINK_FLAGS})
    INSTALL(TARGETS kimonopluginfactory DESTINATION ${PLUGIN_INSTALL_DIR})
ELSE (MONO_INCLUDES)
    MESSAGE(STATUS "Mono includes not found. kimonopluginfactory will not be compiled.")
ENDIF (MONO_INCLUDES)

SET(CS_FLAGS -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -keyfile:${KEYFILE})
ADD_CS_LIBRARY(kde-dotnet "${SRC_CS}" ALL)
ADD_DEPENDENCIES (kde-dotnet qt-dotnet kimono)

INSTALL(TARGETS kimono LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(kde-dotnet)

add_subdirectory(tutorials EXCLUDE_FROM_ALL)
