SET(SRC_CS_ANALOGCLOCK analogclock.cs main.cs)
ADD_CUSTOM_TARGET (analogclock.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:analogclock.exe -r:../../../qt-dotnet.dll ${SRC_CS_ANALOGCLOCK})

