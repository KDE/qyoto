SET(SRC_CS listnames.cs)
ADD_CUSTOM_TARGET (listnames.exe ${GMCS_PATH} -unsafe -warn:0 -out:listnames.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

