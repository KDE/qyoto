SET(SRC_CS t10.cs)
ADD_CUSTOM_TARGET (t10.exe ${GMCS_PATH} -unsafe -warn:0 -out:t10.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

