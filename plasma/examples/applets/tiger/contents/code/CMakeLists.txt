SET(SRC_TIGER ${CMAKE_CURRENT_SOURCE_DIR}/tiger.cs)
SET(CS_FLAGS -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll 
    -r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll
    -r:${LIBRARY_OUTPUT_PATH}/plasma.dll -target:library -target:library )
ADD_CS_EXECUTABLE(main ${SRC_TIGER} ALL)
ADD_DEPENDENCIES(main kde-dotnet plasma)
