SET(SRC_CS t4.cs)
ADD_CUSTOM_TARGET (t4.exe ${GMCS_PATH} -unsafe -warn:0 -out:t4.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

