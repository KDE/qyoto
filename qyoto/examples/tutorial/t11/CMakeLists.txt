SET(SRC_CS cannonfield.cs lcdrange.cs main.cs)
ADD_CUSTOM_TARGET (t11.exe ${GMCS_PATH} -unsafe -warn:0 -out:t11.exe -r:../../../qt-dotnet.dll ${SRC_CS})

