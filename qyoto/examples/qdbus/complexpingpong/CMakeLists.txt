SET(SRC_CS_PING ${CMAKE_CURRENT_SOURCE_DIR}/complexping.cs)
ADD_CUSTOM_TARGET (complexping.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:complexping.exe -r:../../../qt-dotnet.dll ${SRC_CS_PING} COMMENT "Building complexping.exe")

SET(SRC_CS_PONG ${CMAKE_CURRENT_SOURCE_DIR}/complexpong.cs)
ADD_CUSTOM_TARGET (complexpong.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:complexpong.exe -r:../../../qt-dotnet.dll ${SRC_CS_PONG} COMMENT "Building complexpong.exe")

