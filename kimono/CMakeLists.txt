PROJECT(kimono)

find_package(PkgConfig)
find_package(KDE4 REQUIRED)
find_package(Qyoto REQUIRED)
find_package(Smoke COMPONENTS KdeCore KdeUi 
    Kio KParts KHtml
    KFile KNewStuff2 KNewStuff3
    KUtils Akonadi KTextEditor
    Nepomuk Plasma
    Sonnet Soprano
    QtCore QtGui)
set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} ${SMOKE_CMAKE_MODULE_DIR} ${QYOTO_CMAKE_DIR})
enable_language(CSharp)
include(KDE4Defaults)
include(MacroLibrary)
include(MacroOptionalAddBindings)

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/src/Kimono.cs
	${CMAKE_CURRENT_SOURCE_DIR}/src/AssemblyInfo.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kde/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kio/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kparts/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/sonnet/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kns/*.cs)

SET(SRC_KIMONO src/kimono.cpp src/kdehandlers.cpp)

INCLUDE_DIRECTORIES( ${SMOKE_INCLUDE_DIR} ${QYOTO_INCLUDE_DIR} ${QT_INCLUDES}  ${KDE4_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
KDE4_ADD_LIBRARY(kimono SHARED ${SRC_KIMONO})
TARGET_LINK_LIBRARIES(kimono ${QYOTO_LIBRARY} ${SMOKE_BASE_LIBRARY}
                      ${SMOKE_KDECORE_LIBRARY} ${SMOKE_KDEUI_LIBRARY}
                      ${SMOKE_KIO_LIBRARY} ${SMOKE_KPARTS_LIBRARY}
                      ${SMOKE_KFILE_LIBRARY} ${SMOKE_KNEWSTUFF2_LIBRARY}
                      ${SMOKE_KNEWSTUFF3_LIBRARY} ${SMOKE_KUTILS_LIBRARY}
                      ${SMOKE_QTCORE_LIBRARY}
                      ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY}
                      ${KDE4_KDECORE_LIBS} ${KDE4_KIO_LIBS})

# write FindPackage modules for these
pkg_search_module(LIBMONO mono-2 mono)
pkg_search_module(GLIB2 glib-2.0)

macro_log_feature(LIBMONO_FOUND "libmono" "Mono library" "http://www.mono-project.com" FALSE "" "Required to compile kimonopluginfactory")

# if libmono-dev is not installed, then MONO_INCLUDES is not defined and compiling
# the kimonopluginfactory would fail. So, just disable kimonopluginfactory if the
# MONO_INCLUDES is empty and provide some feedback to the user about it.
IF (LIBMONO_FOUND)
    SET(SRC_FACTORY src/kimonopluginfactory.cpp)
    LINK_DIRECTORIES(${LIBMONO_LIBRARY_DIRS} ${GLIB2_LIBRARY_DIRS})
    INCLUDE_DIRECTORIES(${LIBMONO_INCLUDE_DIRS} ${GLIB2_INCLUDE_DIRS})
    ADD_DEFINITIONS(${GLIB2_CFLAGS} ${MONO_CFLAGS})
    KDE4_ADD_PLUGIN(kimonopluginfactory ${SRC_FACTORY})
    TARGET_LINK_LIBRARIES(kimonopluginfactory ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${KDE4_KDECORE_LIBS} ${KDE4_KIO_LIBS} qyoto smokebase smokeqtcore smokeqtgui ${LIBMONO_LIBRARIES})
    INSTALL(TARGETS kimonopluginfactory DESTINATION ${PLUGIN_INSTALL_DIR})
ELSE (LIBMONO_FOUND)
    MESSAGE(STATUS "Mono not found. kimonopluginfactory will not be compiled.")
ENDIF (LIBMONO_FOUND)

CSHARP_ADD_LIBRARY(kde-dotnet "${SRC_CS}" REFERENCES ${QYOTO_ASSEMBLY} COMPILE_FLAGS /warn:0 /keyfile:${QYOTO_KEYFILE})
ADD_DEPENDENCIES (kde-dotnet kimono)

INSTALL(TARGETS kimono LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_ASSEMBLY(kde-dotnet DESTINATION ${LIB_INSTALL_DIR} PACKAGE qyoto)

add_subdirectory(tutorials EXCLUDE_FROM_ALL)
add_subdirectory(examples EXCLUDE_FROM_ALL)

macro_optional_find_package(Soprano)
macro_log_feature(SOPRANO_FOUND "Soprano" "Soprano libraries" "http://soprano.sourceforge.net" FALSE "" "Needed to compile Soprano bindings")

macro_optional_find_package(Nepomuk)
macro_log_feature(NEPOMUK_FOUND "Nepomuk" "Nepomuk libraries" "http://www.kde.org" FALSE "" "Needed to compile Nepomuk bindings")

macro_optional_find_package(KdepimLibs)
macro_log_feature(KDEPIMLIBS_FOUND "kdepimlibs" "KDE PIM libraries" "http://www.kde.org" FALSE "" "Needed to compile Akonadi bindings")

macro_optional_find_package(Akonadi)
macro_log_feature(AKONADI_FOUND "Akonadi" "Akonadi libraries" "http://www.kde.org" FALSE "" "Needed to compile Akonadi bindings")

if (NOT CMAKE_CSharp_COMPILER_LOADED)
    return()
endif (NOT CMAKE_CSharp_COMPILER_LOADED)

macro_optional_add_bindings(KDE4_FOUND "KHTML" khtml)
macro_optional_add_bindings(KDE4_FOUND "KTextEditor" ktexteditor)
macro_optional_add_bindings(KDE4_FOUND "Plasma" plasma)

macro_optional_add_bindings(Soprano_FOUND "Soprano" soprano)

macro_optional_add_bindings(Nepomuk_FOUND "Nepomuk" nepomuk)

if(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
    set(BUILD_Akonadi TRUE)
else(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
    set(BUILD_Akonadi FALSE)
endif(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
macro_optional_add_bindings(BUILD_Akonadi "Akonadi" akonadi)

macro_display_bindings_log()
macro_display_feature_log()
