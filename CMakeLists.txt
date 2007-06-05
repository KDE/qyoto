OPTION(ENABLE_QYOTO "build Qyoto" ON)

set(QYOTO_ENABLED "no")

if(ENABLE_QYOTO)
    FIND_PACKAGE (Mono)
    IF (NOT GMCS_EXECUTABLE)
        MESSAGE (STATUS "gmcs was not found on your system but is needed for Qyoto. Disabling Qyoto.")
    ENDIF (NOT GMCS_EXECUTABLE)

    IF (NOT GACUTIL_EXECUTABLE)
        MESSAGE (STATUS "gacutil was not found on your system but is needed for Qyoto. Disabling Qyoto.")
    ENDIF (NOT GACUTIL_EXECUTABLE)

    IF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
        add_subdirectory( qyoto )
        set(QYOTO_ENABLED "yes")
    ENDIF (GMCS_EXECUTABLE AND GACUTIL_EXECUTABLE)
endif(ENABLE_QYOTO)

message(STATUS "Build Qyoto... " ${QYOTO_ENABLED})
