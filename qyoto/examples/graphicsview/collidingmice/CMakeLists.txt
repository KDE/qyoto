SET(MICE_QRC mice.qrc)
ADD_CUSTOM_TARGET (qrc_mouse.cs ALL ${CSRCC_PATH} -name mice ${MICE_QRC} -o qrc_mouse.cs)

SET(SRC_CS main.cs mouse.cs qrc_mouse.cs)
ADD_CUSTOM_TARGET (collidingmice.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:collidingmice.exe -r:../../../qt-dotnet.dll ${SRC_CS})

