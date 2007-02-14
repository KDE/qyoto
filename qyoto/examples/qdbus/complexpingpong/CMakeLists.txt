SET(SRC_CS_PING complexping.cs)
ADD_CUSTOM_TARGET (complexping.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:complexping.exe -r:../../../qt-dotnet.dll ${SRC_CS_PING})

SET(SRC_CS_PONG complexpong.cs)
ADD_CUSTOM_TARGET (complexpong.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:complexpong.exe -r:../../../qt-dotnet.dll ${SRC_CS_PONG})

