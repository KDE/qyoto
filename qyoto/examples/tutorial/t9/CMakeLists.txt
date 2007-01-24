SET(SRC_CS t9.cs)
ADD_CUSTOM_TARGET (t9.exe ${GMCS_PATH} -unsafe -warn:0 -out:t9.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

