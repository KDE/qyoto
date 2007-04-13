SET(SRC_CS_CAR car_${CMAKE_CURRENT_SOURCE_DIR}/adaptor.cs  ${CMAKE_CURRENT_SOURCE_DIR}/car.cs  ${CMAKE_CURRENT_SOURCE_DIR}/main.cs)
ADD_CUSTOM_TARGET (car.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:car.exe -r:../../../../qt-dotnet.dll ${SRC_CS_CAR} COMMENT "Building car.exe")

