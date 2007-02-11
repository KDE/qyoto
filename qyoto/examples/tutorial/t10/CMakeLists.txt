SET(SRC_T10 t10.cs)
ADD_CUSTOM_TARGET (t10.exe ${GMCS_PATH} -unsafe -warn:0 -out:t10.exe -r:../../../qt-dotnet.dll ${SRC_T10})

