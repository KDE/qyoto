SET(SRC_CS_PING ping.cs)
ADD_CUSTOM_TARGET (ping.exe ALL ${GMCS_PATH} -debug -unsafe -warn:0 -out:ping.exe -r:../../../qt-dotnet.dll ${SRC_CS_PING})

SET(SRC_CS_PONG pong.cs)
ADD_CUSTOM_TARGET (pong.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:pong.exe -r:../../../qt-dotnet.dll ${SRC_CS_PONG})

