project(cs-time-engine)
include(CSharpMacros)

set(SRC_TIMEENGINE timeengine.cs)

set(CS_FLAGS -warn:0 "-r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll,${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll,${LIBRARY_OUTPUT_PATH}/plasma-dll.dll")
add_cs_library(time-engine "${SRC_TIMEENGINE}" ALL)

add_dependencies(time-engine plasma)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-time/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/time-engine.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-time/contents/code RENAME main)
install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-time)
