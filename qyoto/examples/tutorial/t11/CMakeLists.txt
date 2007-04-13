SET(SRC_T11 ${CMAKE_CURRENT_SOURCE_DIR}/cannonfield.cs ${CMAKE_CURRENT_SOURCE_DIR}/lcdrange.cs ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (t11.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:t11.exe -r:../../../qt-dotnet.dll ${SRC_T11} COMMENT "Building t11.exe")

