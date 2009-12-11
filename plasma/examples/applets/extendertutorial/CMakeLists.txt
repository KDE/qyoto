project(cs-extender-tutorial)

set(SRC_EXTENDER_TUTORIAL extender_tutorial.cs)

csharp_add_library(csharp-extender-tutorial "${SRC_EXTENDER_TUTORIAL}" REFERENCES qt-dotnet kde-dotnet plasma-dll COMPILE_FLAGS /warn:0)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/csharp-extender-tutorial.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial/contents/code RENAME main)

install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-extender-tutorial)


