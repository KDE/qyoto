SET(SRC_CS t5.cs)
ADD_CUSTOM_TARGET (t5.exe ${GMCS_PATH} -unsafe -warn:0 -out:t5.exe -r:../../../qt-dotnet.dll ${SRC_CS})

