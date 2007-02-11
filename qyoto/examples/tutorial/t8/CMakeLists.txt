SET(SRC_T8 t8.cs)
ADD_CUSTOM_TARGET (t8.exe ${GMCS_PATH} -unsafe -warn:0 -out:t8.exe -r:../../../qt-dotnet.dll ${SRC_T8})

