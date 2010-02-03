PROJECT (qyoto)

# find Qt4
IF (NOT QT4_FOUND)
    FIND_PACKAGE (Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

# source files
SET(SRC_QYOTO_SHARED src/emitsignal.cpp
    src/invokeslot.cpp
    src/methodcall.cpp
    src/methodreturnvalue.cpp
    src/signalreturnvalue.cpp
    src/slotreturnvalue.cpp
    src/virtualmethodcall.cpp
    src/virtualmethodreturnvalue.cpp
    src/qyotosmokebinding.cpp
    src/handlers.cpp
    src/qyotoshared.cpp)

SET(SRC_QYOTO src/qyoto.cpp)

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

INCLUDE_DIRECTORIES (${QT_INCLUDES} ${CMAKE_SOURCE_DIR}/smoke ${CMAKE_SOURCE_DIR}/smoke/qt ${CMAKE_CURRENT_SOURCE_DIR}/src)
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})

ADD_LIBRARY (qyotoshared SHARED ${SRC_QYOTO_SHARED})
TARGET_LINK_LIBRARIES (qyotoshared smokeqtcore smokeqtgui smokeqtxml smokeqtopengl smokeqtsql smokeqtnetwork smokeqtnetwork smokeqtdbus smokeqtsvg
                       ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${QT_QTNETWORK_LIBRARY} ${QT_QTDBUS_LIBRARY})
set_target_properties(qyotoshared PROPERTIES VERSION 1.0.0 SOVERSION 1 COMPILE_DEFINITIONS QYOTOSHARED_BUILDING)

ADD_LIBRARY (qyoto MODULE ${SRC_QYOTO})
TARGET_LINK_LIBRARIES (qyoto qyotoshared
                       smokeqtcore smokeqtgui smokeqtxml smokeqtopengl smokeqtsql smokeqtnetwork smokeqtnetwork smokeqtdbus smokeqtsvg
                       ${QT_QTCORE_LIBRARY} ${QT_QTGUI_LIBRARY} ${QT_QTNETWORK_LIBRARY} ${QT_QTDBUS_LIBRARY})

CSHARP_ADD_LIBRARY(qt-dotnet ${SRC_CS_QYOTO} COMPILE_FLAGS /warn:0 "/keyfile:${KEYFILE}" UNSAFE COMPILE_DEFINITIONS DEBUG)
SET_PROPERTY(TARGET qt-dotnet PROPERTY pkg-config_template_basename "qyoto")

ADD_DEPENDENCIES (qt-dotnet qyoto)

GET_LIBRARY_OUTPUT_DIR(library_target_dir)
FILE(WRITE ${library_target_dir}/qt-dotnet.dll.config "<configuration><dllmap dll=\"libqyotoshared\" target=\"libqyotoshared.so.1\"/></configuration>")

install_assembly(qt-dotnet DESTINATION lib PACKAGE qyoto)
INSTALL(TARGETS qyoto LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL(TARGETS qyotoshared LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL(FILES src/emitsignal.h src/invokeslot.h src/marshall.h src/methodcall.h src/methodreturnvalue.h
src/qyoto.h src/qyotosmokebinding.h src/signalreturnvalue.h src/slotreturnvalue.h
src/smokeqyoto.h src/virtualmethodcall.h src/virtualmethodreturnvalue.h DESTINATION include/qyoto)


ADD_SUBDIRECTORY(tools)
ADD_SUBDIRECTORY(examples EXCLUDE_FROM_ALL)
