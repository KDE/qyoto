SET(SRC_T3 t3.cs)
ADD_CUSTOM_TARGET (t3.exe ${GMCS_PATH} -unsafe -warn:0 -out:t3.exe -r:../../../qt-dotnet.dll ${SRC_T3})

