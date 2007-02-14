SET(SRC_T12 cannonfield.cs lcdrange.cs main.cs)
ADD_CUSTOM_TARGET (t12.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t12.exe -r:../../../qt-dotnet.dll ${SRC_T12} COMMENT "Building t12.exe")

