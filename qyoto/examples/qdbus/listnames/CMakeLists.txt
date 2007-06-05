SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/listnames.cs)
SET(CS_FLAGS -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll)
ADD_CS_EXECUTABLE(listnames "${SRC_CS}" ALL)
