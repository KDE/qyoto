SET(SRC_CS_PING ping.cs)
ADD_CUSTOM_TARGET (ping.exe ${GMCS_PATH} -unsafe -warn:0 -out:ping.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS_PING})

SET(SRC_CS_PONG pong.cs)
ADD_CUSTOM_TARGET (pong.exe ${GMCS_PATH} -unsafe -warn:0 -out:pong.exe -addmodule:../../../qt-dotnet.dll ${SRC_CS_PONG})

