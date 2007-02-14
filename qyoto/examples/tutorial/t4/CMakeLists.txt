SET(SRC_T4 t4.cs)
ADD_CUSTOM_TARGET (t4.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t4.exe -r:../../../qt-dotnet.dll ${SRC_T4})

