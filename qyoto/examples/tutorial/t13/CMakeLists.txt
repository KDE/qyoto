SET(SRC_T13 cannonfield.cs gameboard.cs lcdrange.cs main.cs)
ADD_CUSTOM_TARGET (t13.exe ${GMCS_PATH} -unsafe -warn:0 -out:t13.exe -r:../../../qt-dotnet.dll ${SRC_T13})

