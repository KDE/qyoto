OPTION(ENABLE_QYOTO "build Qyoto" ON)

set(QYOTO_ENABLED "no")

if(ENABLE_QYOTO)
    # find 'gmcs'
    MESSAGE (STATUS "Looking for gmcs")
    FIND_PROGRAM (GMCS_PATH gmcs)
    IF (NOT GMCS_PATH)
        MESSAGE (STATUS "Looking for gmcs - not found.")
        MESSAGE (STATUS "gmcs was not found on your system but is needed for Qyoto. Disabling Qyoto.")
    ELSE (NOT GMCS_PATH)
        MESSAGE (STATUS "Looking for gmcs - found - ${GMCS_PATH}")
    ENDIF (NOT GMCS_PATH)

    # find 'gacutil'
    MESSAGE (STATUS "Looking for gacutil")
    FIND_PROGRAM (GACUTIL_PATH gacutil)
    IF (NOT GACUTIL_PATH)
        MESSAGE (STATUS "Looking for gacutil - not found.")
        MESSAGE (STATUS "gacutil was not found on your system but is needed for Qyoto. Disabling Qyoto.")
    ELSE (NOT GACUTIL_PATH)
        MESSAGE (STATUS "Looking for gacutil - found - ${GACUTIL_PATH}")
    ENDIF (NOT GACUTIL_PATH)

    IF (GMCS_PATH AND GACUTIL_PATH)
        add_subdirectory( qyoto )
        set(QYOTO_ENABLED "yes")
    ENDIF (GMCS_PATH AND GACUTIL_PATH)
endif(ENABLE_QYOTO)

message(STATUS "Build Qyoto... " ${QYOTO_ENABLED})
