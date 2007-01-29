SET(SRC_CS t2.cs)
ADD_CUSTOM_TARGET (t2.exe ${GMCS_PATH} -unsafe -warn:0 -out:t2.exe -r:../../../qt-dotnet.dll ${SRC_CS})

