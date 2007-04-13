SET(SRC_T6 ${CMAKE_CURRENT_SOURCE_DIR}/t6.cs)
ADD_CUSTOM_TARGET (t6.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t6.exe -r:../../../qt-dotnet.dll ${SRC_T6} COMMENT "Building t6.exe")

