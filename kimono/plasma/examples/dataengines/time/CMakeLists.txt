project(cs-time-engine)

set(SRC_TIMEENGINE timeengine.cs)

csharp_add_library(time-engine "${SRC_TIMEENGINE}" REFERENCES qt-dotnet kde-dotnet plasma-dll COMPILE_FLAGS /warn:0)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-time/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/time-engine.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-time/contents/code RENAME main)
install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-time)
