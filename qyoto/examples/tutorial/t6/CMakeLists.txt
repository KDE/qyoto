SET(SRC_CS t6.cs)
ADD_CUSTOM_TARGET (t6.exe ${GMCS_PATH} -unsafe -warn:0 -out:t6.exe -r:../../../qt-dotnet.dll ${SRC_CS})

