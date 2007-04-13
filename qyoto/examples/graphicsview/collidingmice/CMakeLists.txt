SET(MICE_QRC ${CMAKE_CURRENT_SOURCE_DIR}/mice.qrc)
ADD_CUSTOM_TARGET (qrc_mouse.cs ALL ${CSRCC_PATH} -name mice ${MICE_QRC} -o qrc_mouse.cs COMMENT "Building qrc_mouse.cs")

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/main.cs ${CMAKE_CURRENT_SOURCE_DIR}/mouse.cs ${CMAKE_CURRENT_BINARY_DIR}/qrc_mouse.cs)
ADD_CUSTOM_TARGET (collidingmice.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:collidingmice.exe -r:../../../qt-dotnet.dll ${SRC_CS} COMMENT "Building collidingmice.exe")

ADD_DEPENDENCIES (collidingmice.exe qrc_mouse.cs)
