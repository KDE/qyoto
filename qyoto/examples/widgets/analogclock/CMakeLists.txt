SET(SRC_CS_ANALOGCLOCK ${CMAKE_CURRENT_SOURCE_DIR}/analogclock.cs ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (analogclock.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:analogclock.exe -r:../../../qt-dotnet.dll ${SRC_CS_ANALOGCLOCK} COMMENT "Building analogclock.exe")

