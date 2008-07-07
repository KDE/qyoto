PROJECT(plasma-sharp)

IF (NOT PLASMA_FOUND)
	FIND_PACKAGE(Plasma REQUIRED)
ENDIF (NOT PLASMA_FOUND)

IF (NOT QT4_FOUND)
	FIND_PACKAGE(Qt4 REQUIRED)
ENDIF (NOT QT4_FOUND)

add_subdirectory( examples )

SET(SRC_CPP src/plasma.cpp src/plasmahandlers.cpp)

SET(SRC_CS src/AssemblyInfo.cs 
 src/PlasmaScripting_DataEngine.cs
 src/PlasmaScripting_Applet.cs
 src/PlasmaScripting_QGraphicsWidget.cs
 src/Plasma.cs 
plasma/*.cs)

SET(SRC_PLASMASCRIPTING src/PlasmaScripting_Applet.cs)

SET(SRC_PLASMASCRIPTENGINEKIMONO_APPLET
    src/PlasmaScriptengineKimono_Applet.cs)

SET(SRC_PLASMASCRIPTENGINEKIMONO_DATAENGINE
    src/PlasmaScriptengineKimono_DataEngine.cs)

INCLUDE_DIRECTORIES(${CMAKE_SOURCE_DIR}/smoke 
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src ${QT_INCLUDES})
LINK_DIRECTORIES (${LIBRARY_OUTPUT_PATH})
ADD_LIBRARY(plasma-sharp MODULE ${SRC_CPP})
ADD_DEPENDENCIES(plasma-sharp smokeplasma kde-dotnet)
TARGET_LINK_LIBRARIES(plasma-sharp smokeqt smokekde smokeplasma qyotoshared ${PLASMA_LIBS})

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(plasma "${SRC_CS}" ALL)

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/plasma.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(Applet "${SRC_PLASMASCRIPTENGINEKIMONO_APPLET}" ALL)
ADD_DEPENDENCIES(Applet plasma)

SET(CS_FLAGS -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll -r:${LIBRARY_OUTPUT_PATH}/plasma.dll -warn:0 -keyfile:${KEYFILE})
ADD_CS_LIBRARY(DataEngine "${SRC_PLASMASCRIPTENGINEKIMONO_DATAENGINE}" ALL)
ADD_DEPENDENCIES(DataEngine plasma)

INSTALL(TARGETS plasma-sharp LIBRARY DESTINATION ${LIB_INSTALL_DIR})
INSTALL_GAC(plasma)

install(FILES ${LIBRARY_OUTPUT_PATH}/Applet.dll DESTINATION ${DATA_INSTALL_DIR}/plasma_scriptengine_kimono)
install(FILES plasma-scriptengine-kimono-applet.desktop DESTINATION ${SERVICES_INSTALL_DIR})

install(FILES ${LIBRARY_OUTPUT_PATH}/DataEngine.dll DESTINATION ${DATA_INSTALL_DIR}/plasma_scriptengine_kimono)
install(FILES plasma-scriptengine-kimono-dataengine.desktop DESTINATION ${SERVICES_INSTALL_DIR})
