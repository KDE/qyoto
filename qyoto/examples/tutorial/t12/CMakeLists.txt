SET(SRC_T12 ${CMAKE_CURRENT_SOURCE_DIR}/cannonfield.cs ${CMAKE_CURRENT_SOURCE_DIR}/lcdrange.cs ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (t12.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t12.exe -r:../../../qt-dotnet.dll ${SRC_T12} COMMENT "Building t12.exe")

