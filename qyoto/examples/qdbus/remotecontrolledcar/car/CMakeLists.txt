SET(SRC_CS_CAR car_adaptor.cs  car.cs  main.cs)
ADD_CUSTOM_TARGET (car.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:car.exe -r:../../../../qt-dotnet.dll ${SRC_CS_CAR} COMMENT "Building car.exe")

