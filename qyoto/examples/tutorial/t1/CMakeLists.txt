SET(SRC_CS t1.cs)
ADD_CUSTOM_TARGET (t1.exe ${GMCS_PATH} -unsafe -warn:0 -out:t1.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS})

