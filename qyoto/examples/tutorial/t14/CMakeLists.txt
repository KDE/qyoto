SET(SRC_T14 ${CMAKE_CURRENT_SOURCE_DIR}/cannonfield.cs ${CMAKE_CURRENT_SOURCE_DIR}/gameboard.cs ${CMAKE_CURRENT_SOURCE_DIR}/lcdrange.cs ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (t14.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t14.exe -r:../../../qt-dotnet.dll ${SRC_T14} COMMENT "Building t14.exe")

