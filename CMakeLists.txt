OPTION(ENABLE_QYOTO "build Qyoto" ON)
OPTION(ENABLE_QSCINTILLA_SHARP "build QScintillaSharp" OFF)
OPTION(ENABLE_KHTML_SHARP "build KHTML" ON)
OPTION(ENABLE_KIMONO "build Kimono" ON)

SET(QYOTO_ENABLED "no")
SET(QSCINTILLA_SHARP_ENABLED "no")
SET(KIMONO_ENABLED "no")
SET(KHTML_SHARP_ENABLED "no")

SET(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)

if(ENABLE_QYOTO)
    macro_optional_find_package (Mono)

    IF (NOT GMCS_EXECUTABLE)
        MESSAGE (STATUS "gmcs was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GMCS_EXECUTABLE)

    IF (NOT GACUTIL_EXECUTABLE)
        MESSAGE (STATUS "gacutil was not found on your system but is needed for Qyoto.")
    ENDIF (NOT GACUTIL_EXECUTABLE)

    # following does check for mono-cecil which may packaged into an own package
    # depending on your distributor. cecil is needed within CSharpMacros.cmake for
    # the INSTALL_GAC macro. So, let's check here if cecil is available rather then
    # assuming it is and then break compile (happens e.g. on kubuntu 7.10).
    INCLUDE(FindPkgConfig)
    IF(NOT WIN32)
        PKG_SEARCH_MODULE(MONO_CECIL mono-cecil)
        PKG_SEARCH_MODULE(MONO_CECIL cecil)
        IF (NOT MONO_CECIL_FOUND AND NOT CECIL_FOUND)
            message("Failed to find mono-cecil needed by CSharp. Please install libmono-devel.")
        ELSE (NOT MONO_CECIL_FOUND AND NOT CECIL_FOUND)
            set(MONO_CECIL_FOUND "yes")
        ENDIF (NOT MONO_CECIL_FOUND AND NOT CECIL_FOUND)
    ELSE(NOT WIN32)
        set(MONO_CECIL_FOUND "yes")
    ENDIF(NOT WIN32)

    IF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE AND MONO_CECIL_FOUND)
        add_subdirectory( qyoto )
        set(QYOTO_ENABLED "yes")

	IF(ENABLE_QSCINTILLA_SHARP AND QSCINTILLA_FOUND)
		FIND_PACKAGE(QScintilla REQUIRED)
		SET(QSCINTILLA_SHARP_ENABLED "yes")
		ADD_SUBDIRECTORY(qscintilla)
	ENDIF(ENABLE_QSCINTILLA_SHARP AND QSCINTILLA_FOUND)
	
	IF(ENABLE_KIMONO)
		SET(KIMONO_ENABLED "yes")
		ADD_SUBDIRECTORY(kimono)
	ENDIF(ENABLE_KIMONO)
	
	IF(ENABLE_KHTML_SHARP)
		SET(KHTML_SHARP_ENABLED "yes")
		ADD_SUBDIRECTORY(khtml)
	ENDIF(ENABLE_KHTML_SHARP)
	
	IF(Soprano_FOUND)
		SET(SOPRANO_SHARP_ENABLED "yes")
		ADD_SUBDIRECTORY(soprano)
	ENDIF(Soprano_FOUND)
	
	IF(PLASMA_FOUND)
		SET(PLASMA_SHARP_ENABLED "yes")
		ADD_SUBDIRECTORY(plasma)
	ENDIF(PLASMA_FOUND)

    ENDIF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE AND MONO_CECIL_FOUND)
endif(ENABLE_QYOTO)

message(STATUS "Build Qyoto... " ${QYOTO_ENABLED})
message(STATUS "Build QScintillaSharp... " ${QSCINTILLA_SHARP_ENABLED})
message(STATUS "Build SopranoSharp... " ${SOPRANO_SHARP_ENABLED})
message(STATUS "Build PlasmaSharp... " ${PLASMA_SHARP_ENABLED})
message(STATUS "Build Kimono... " ${KIMONO_ENABLED})
message(STATUS "Build KHTMLSharp... " ${KHTML_SHARP_ENABLED})
