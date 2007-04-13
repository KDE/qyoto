SET(SRC_T13 ${CMAKE_CURRENT_SOURCE_DIR}/cannonfield.cs ${CMAKE_CURRENT_SOURCE_DIR}/gameboard.cs ${CMAKE_CURRENT_SOURCE_DIR}/lcdrange.cs ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (t13.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t13.exe -r:../../../qt-dotnet.dll ${SRC_T13} COMMENT "Building t13.exe")

