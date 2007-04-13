SET(SRC_T8 ${CMAKE_CURRENT_SOURCE_DIR}/t8.cs)
ADD_CUSTOM_TARGET (t8.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t8.exe -r:../../../qt-dotnet.dll ${SRC_T8} COMMENT "Building t8.exe")

