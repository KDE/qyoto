SET(SRC_T2 ${CMAKE_CURRENT_SOURCE_DIR}/t2.cs)
ADD_CUSTOM_TARGET (t2.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t2.exe -r:../../../qt-dotnet.dll ${SRC_T2} COMMENT "Building t2.exe")

