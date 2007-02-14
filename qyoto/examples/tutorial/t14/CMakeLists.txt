SET(SRC_T14 cannonfield.cs gameboard.cs lcdrange.cs main.cs)
ADD_CUSTOM_TARGET (t14.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t14.exe -r:../../../qt-dotnet.dll ${SRC_T14})

