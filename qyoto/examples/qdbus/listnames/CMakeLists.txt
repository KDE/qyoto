SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/listnames.cs)
ADD_CUSTOM_TARGET (listnames.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:listnames.exe -r:../../../qt-dotnet.dll ${SRC_CS} COMMENT "Building listnames.exe")

