SET(SRC_CS t8.cs)
ADD_CUSTOM_TARGET (t8.exe ${GMCS_PATH} -unsafe -warn:0 -out:t8.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

