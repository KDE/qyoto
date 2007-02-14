SET(SRC_CS listnames.cs)
ADD_CUSTOM_TARGET (listnames.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:listnames.exe -r:../../../qt-dotnet.dll ${SRC_CS} COMMENT "Building listnames.exe")

