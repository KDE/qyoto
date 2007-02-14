SET(SRC_T1 t1.cs)
ADD_CUSTOM_TARGET (t1.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t1.exe -r:../../../qt-dotnet.dll ${SRC_T1})
