SET(SRC_T7 lcdrange.cs)
ADD_CUSTOM_TARGET (t7.exe ${GMCS_PATH} -unsafe -warn:0 -out:t7.exe -r:../../../qt-dotnet.dll ${SRC_T7})

