SET(SRC_T5 ${CMAKE_CURRENT_SOURCE_DIR}/t5.cs)
ADD_CUSTOM_TARGET (t5.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t5.exe -r:../../../qt-dotnet.dll ${SRC_T5} COMMENT "Building t5.exe")

