OPTION(ENABLE_QYOTO "build Qyoto" ON)
OPTION(ENABLE_QSCINTILLA_SHARP "build QScintillaSharp" OFF)
OPTION(ENABLE_SOPRANO_SHARP "build SopranoSharp" ON)
OPTION(ENABLE_PLASMA_SHARP "build PlasmaSharp" OFF)
OPTION(ENABLE_KIMONO "build Kimono" ON)
OPTION(ENABLE_KHTML_SHARP "build KHTML" ON)

set(QYOTO_ENABLED "no")

SET(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)

if(ENABLE_QYOTO)
    FIND_PACKAGE (Mono)
    IF (NOT GMCS_EXECUTABLE)
        MESSAGE (STATUS "gmcs was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GMCS_EXECUTABLE)

    IF (NOT GACUTIL_EXECUTABLE)
        MESSAGE (STATUS "gacutil was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GACUTIL_EXECUTABLE)

    IF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
        add_subdirectory( qyoto )
#         add_subdirectory( kimono )
        set(QYOTO_ENABLED "yes")
    ENDIF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
endif(ENABLE_QYOTO)

SET(QSCINTILLA_SHARP_ENABLED "no")

IF(ENABLE_QSCINTILLA_SHARP AND QSCINTILLA_FOUND)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for QscintillaSharp. You either didn't enable it or some of its dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	FIND_PACKAGE(QScintilla REQUIRED)
	SET(QSCINTILLA_SHARP_ENABLED "yes")
	ADD_SUBDIRECTORY(qscintilla)
ENDIF(ENABLE_QSCINTILLA_SHARP AND QSCINTILLA_FOUND)

SET(SOPRANO_SHARP_ENABLED "no")

IF(ENABLE_SOPRANO_SHARP AND Soprano_FOUND)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for SopranoSharp. You either didn't enable it or some of its dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	SET(SOPRANO_SHARP_ENABLED "yes")
	ADD_SUBDIRECTORY(soprano)
ENDIF(ENABLE_SOPRANO_SHARP AND Soprano_FOUND)

IF(ENABLE_PLASMA_SHARP)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for PlasmaSharp. You either didn't enable it or some of its dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	SET(PLASMA_SHARP_ENABLED "yes")
	ADD_SUBDIRECTORY(plasma)
ENDIF(ENABLE_PLASMA_SHARP)

SET(KIMONO_ENABLED "no")

IF(ENABLE_KIMONO)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for Kimono. You either didn't enable it or some of its dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	SET(KIMONO_ENABLED "yes")
	ADD_SUBDIRECTORY(kimono)
ENDIF(ENABLE_KIMONO)

IF(ENABLE_KHTML_SHARP)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for KHTML. You either didn't enable it or some of its dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	SET(KHTML_ENABLED "yes")
	ADD_SUBDIRECTORY(khtml)
ENDIF(ENABLE_KHTML_SHARP)

message(STATUS "Build Qyoto... " ${QYOTO_ENABLED})
message(STATUS "Build QScintillaSharp... " ${QSCINTILLA_SHARP_ENABLED})
message(STATUS "Build SopranoSharp... " ${SOPRANO_SHARP_ENABLED})
message(STATUS "Build PlasmaSharp... " ${PLASMA_SHARP_ENABLED})
message(STATUS "Build Kimono... " ${KIMONO_ENABLED})
message(STATUS "Build KHTMLSharp... " ${KHTML_ENABLED})
