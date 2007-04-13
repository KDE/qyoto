SET(SRC_T9 ${CMAKE_CURRENT_SOURCE_DIR}/t9.cs)
ADD_CUSTOM_TARGET (t9.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t9.exe -r:../../../qt-dotnet.dll ${SRC_T9} COMMENT "Building t9.exe")

