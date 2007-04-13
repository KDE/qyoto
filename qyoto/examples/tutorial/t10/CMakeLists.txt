SET(SRC_T10 ${CMAKE_CURRENT_SOURCE_DIR}/t10.cs)
ADD_CUSTOM_TARGET (t10.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t10.exe -r:../../../qt-dotnet.dll ${SRC_T10} COMMENT "Building t10.exe")

