OPTION(ENABLE_QYOTO "build Qyoto" ON)
OPTION(ENABLE_QSCINTILLA_SHARP "build QScintillaSharp" ON)
# OPTION(ENABLE_KIMONO "build Kimono" ON)

set(QYOTO_ENABLED "no")

SET(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)

if(ENABLE_QYOTO)
    FIND_PACKAGE (Mono)
    IF (NOT GMCS_EXECUTABLE)
        MESSAGE (FATAL_ERROR "gmcs was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GMCS_EXECUTABLE)

    IF (NOT GACUTIL_EXECUTABLE)
        MESSAGE (FATAL_ERROR "gacutil was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GACUTIL_EXECUTABLE)

    IF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
        add_subdirectory( qyoto )
        set(QYOTO_ENABLED "yes")
    ENDIF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
endif(ENABLE_QYOTO)

SET(QSCINTILLA_SHARP_ENABLED "no")

IF(ENABLE_QSCINTILLA_SHARP)
	IF (NOT QYOTO_ENABLED)
		MESSAGE(FATAL_ERROR "Qyoto is needed for QscintillaSharp. You either didn't enable it or some of it's dependencies aren't met.")
	ENDIF (NOT QYOTO_ENABLED)
	
	FIND_PACKAGE(QScintilla REQUIRED)
	SET(QSCINTILLA_SHARP_ENABLED "yes")
	ADD_SUBDIRECTORY(qscintilla)
ENDIF(ENABLE_QSCINTILLA_SHARP)

# SET(KIMONO_ENABLED "no")
# 
# IF(ENABLE_KIMONO)
# 	IF (NOT QYOTO_ENABLED)
# 		MESSAGE(FATAL_ERROR "Qyoto is needed for Kimono. You either didn't enable it or some of it's dependencies aren't met.")
# 	ENDIF (NOT QYOTO_ENABLED)
# 	
# 	SET(KIMONO_ENABLED "yes")
# 	ADD_SUBDIRECTORY(kimono)
# ENDIF(ENABLE_KIMONO)

message(STATUS "Build Qyoto... " ${QYOTO_ENABLED})
message(STATUS "Build QScintillaSharp... " ${QSCINTILLA_SHARP_ENABLED})
# message(STATUS "Build Kimono... " ${KIMONO_ENABLED})
