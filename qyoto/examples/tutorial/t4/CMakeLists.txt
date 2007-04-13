SET(SRC_T4 ${CMAKE_CURRENT_SOURCE_DIR}/t4.cs)
ADD_CUSTOM_TARGET (t4.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t4.exe -r:../../../qt-dotnet.dll ${SRC_T4} COMMENT "Building t4.exe")

