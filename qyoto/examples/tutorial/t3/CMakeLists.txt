SET(SRC_CS t3.cs)
ADD_CUSTOM_TARGET (t3.exe ${GMCS_PATH} -unsafe -warn:0 -out:t3.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

