PROJECT (qyoto)

cmake_minimum_required(VERSION 2.6)

find_package(Qt4 REQUIRED)
find_package(Smoke COMPONENTS QtCore QtGui QtXml QtOpenGl QtSql QtNetwork QtDbus QtSvg QtScript QtTest QSci QImageBlitz Phonon)
include_directories(${SMOKE_INCLUDE_DIR} ${QT_INCLUDES} ${CMAKE_CURRENT_SOURCE_DIR}/src)
set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} ${CMAKE_CURRENT_SOURCE_DIR}/cmake ${CMAKE_CURRENT_BUILD_DIR}/cmake ${SMOKE_CMAKE_MODULE_DIR})
include(MacroOptionalFindPackage)
include(MacroOptionalAddBindings)
include(MacroLogFeature)
enable_language(CSharp OPTIONAL)
set(LIB_INSTALL_DIR ${CMAKE_INSTALL_PREFIX}/lib${LIB_SUFFIX}/)

set(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)
install(FILES ${KEYFILE} DESTINATION share/qyoto )
set( UICS_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/uics/uics )
set( CSRCC_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/tools/csrcc/csrcc )

# source files
SET(SRC_QYOTO
    src/callbacks.cpp
    src/emitsignal.cpp
    src/handlers.cpp
    src/invokeslot.cpp
    src/methodcall.cpp
    src/methodreturnvalue.cpp
    src/modelfunctions.cpp
    src/qdbus_interop.cpp
    src/qmetatype_interop.cpp
    src/qobject_interop.cpp
    src/qvariant_interop.cpp
    src/qyoto.cpp
    src/qyotosmokebinding.cpp
    src/signalreturnvalue.cpp
    src/slotreturnvalue.cpp
    src/util.cpp
    src/virtualmethodcall.cpp
    src/virtualmethodreturnvalue.cpp
)

SET(SRC_CS_QYOTO src/SmokeInvocation.cs
    src/SmokeMarshallers.cs
    src/Qyoto.cs
    src/QyotoMetaData.cs
    src/AssemblyInfo.cs
    core/*.cs
    gui/*.cs
    network/*.cs
    sql/*.cs
    xml/*.cs
    svg/*.cs
    opengl/*.cs
    qdbus/*.cs)

LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})

ADD_LIBRARY (qyoto SHARED ${SRC_QYOTO})
TARGET_LINK_LIBRARIES (qyoto ${SMOKE_BASE_LIBRARY} 
        ${SMOKE_QTCORE_LIBRARY} 
        ${SMOKE_QTGUI_LIBRARY}
        ${SMOKE_QTXML_LIBRARY}
        ${SMOKE_QTOPENGL_LIBRARY}
        ${SMOKE_QTSQL_LIBRARY}
        ${SMOKE_QTNETWORK_LIBRARY}
        ${SMOKE_QTDBUS_LIBRARY}
        ${SMOKE_QTSVG_LIBRARY}
        ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${QT_QTNETWORK_LIBRARY} ${QT_QTDBUS_LIBRARY})
set_target_properties(qyoto PROPERTIES VERSION 2.0.0 SOVERSION 2 COMPILE_DEFINITIONS QYOTO_BUILDING)


CSHARP_ADD_LIBRARY(qt-dotnet ${SRC_CS_QYOTO} COMPILE_FLAGS /warn:0 "/keyfile:${KEYFILE}" UNSAFE COMPILE_DEFINITIONS DEBUG)
SET_PROPERTY(TARGET qt-dotnet PROPERTY pkg-config_template_basename "qyoto")

ADD_DEPENDENCIES (qt-dotnet qyoto)

GET_LIBRARY_OUTPUT_DIR(library_target_dir)
FILE(WRITE ${library_target_dir}/qt-dotnet.dll.config "<configuration><dllmap dll=\"qyoto\" target=\"libqyoto.so.2\"/></configuration>")

install_assembly(qt-dotnet DESTINATION lib PACKAGE qyoto)
INSTALL(TARGETS qyoto EXPORT QyotoExport LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL(FILES src/emitsignal.h src/callbacks.h src/invokeslot.h src/marshall.h src/marshall_macros.h src/methodcall.h src/methodreturnvalue.h src/qyoto.h src/qyotosmokebinding.h src/signalreturnvalue.h src/slotreturnvalue.h
src/smokeqyoto.h src/virtualmethodcall.h src/virtualmethodreturnvalue.h DESTINATION include/qyoto)
INSTALL(EXPORT QyotoExport DESTINATION ${CMAKE_INSTALL_PREFIX}/share/qyoto/cmake NAMESPACE QYOTO_ )

add_subdirectory(tools)
add_subdirectory(examples EXCLUDE_FROM_ALL)
macro_log_feature(CMAKE_CSharp_COMPILER_LOADED "C# compiler" "Mono or the .NET framework" "http://www.mono-project.com" FALSE "" "Required to compile the C# bindings")

macro_optional_find_package(QScintilla)
macro_log_feature(QSCINTILLA_FOUND "QScintilla2" "QScintilla2 libraries" "http://www.riverbankcomputing.co.uk/software/qscintilla/intro" FALSE "" "Needed to compile QScintilla2 bindings")

macro_optional_find_package(QImageBlitz)
macro_log_feature(QIMAGEBLITZ_FOUND "QImageBlitz" "QImageBlitz library" "http://www.kde.org" FALSE "" "Needed to compile QImageBlitz bindings")

macro_optional_find_package(Phonon)
macro_log_feature(PHONON_FOUND "Phonon" "Phonon multimedia framework" "http://www.kde.org" FALSE "" "Needed to compile Phonon bindings")


macro_optional_add_bindings(QT_QTSCRIPT_FOUND "QtScript" qtscript)
macro_optional_add_bindings(QT_QTTEST_FOUND "QtTest" qttest)
macro_optional_add_bindings(QT_QTUITOOLS_FOUND "QtUiTools" qtuitools)
macro_optional_add_bindings(QT_QTWEBKIT_FOUND "QtWebKit" qtwebkit)
macro_optional_add_bindings(PHONON_FOUND "Phonon" phonon)
macro_optional_add_bindings(QSCINTILLA_FOUND "QScintilla" qscintilla)

# important: add the cmake subdir after all install_assembly() calls
add_subdirectory(cmake)

macro_display_bindings_log()
macro_display_feature_log()
