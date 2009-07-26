project(cs-extender-tutorial)
include(CSharpMacros)

set(SRC_EXTENDER_TUTORIAL extender_tutorial.cs)

set(CS_FLAGS -warn:0 "-r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll,${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll,${LIBRARY_OUTPUT_PATH}/plasma-dll.dll")
add_cs_library(csharp-extender-tutorial "${SRC_EXTENDER_TUTORIAL}" ALL)

add_dependencies(csharp-extender-tutorial plasma-dll)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/csharp-extender-tutorial.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial/contents/code RENAME main)

install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial)


