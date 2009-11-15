SET(MICE_QRC ${CMAKE_CURRENT_SOURCE_DIR}/mice.qrc)
ADD_CUSTOM_COMMAND (OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/qrc_mouse.cs COMMAND ${CSRCC_EXECUTABLE} -name mice ${MICE_QRC} -o qrc_mouse.cs COMMENT "Generating qrc_mouse.cs")

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/main.cs ${CMAKE_CURRENT_SOURCE_DIR}/mouse.cs ${CMAKE_CURRENT_BINARY_DIR}/qrc_mouse.cs)
SET(CS_FLAGS -warn:0 -unsafe -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll)
ADD_CS_EXECUTABLE(collidingmice "${SRC_CS}" ALL)
ADD_DEPENDENCIES(collidingmice qt-dotnet)
