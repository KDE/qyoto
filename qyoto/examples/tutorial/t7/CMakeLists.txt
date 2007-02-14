SET(SRC_T7 lcdrange.cs)
ADD_CUSTOM_TARGET (t7.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t7.exe -r:../../../qt-dotnet.dll ${SRC_T7} COMMENT "Building t7.exe")

