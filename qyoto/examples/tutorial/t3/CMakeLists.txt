SET(SRC_T3 ${CMAKE_CURRENT_SOURCE_DIR}/t3.cs)
ADD_CUSTOM_TARGET (t3.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t3.exe -r:../../../qt-dotnet.dll ${SRC_T3} COMMENT "Building t3.exe")

