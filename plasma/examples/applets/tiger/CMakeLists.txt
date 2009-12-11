project(cs-tiger)

set(SRC_TIGER tiger.cs)

csharp_add_library(csharp-tiger "${SRC_TIGER}" REFERENCES qt-dotnet kde-dotnet plasma-dll COMPILE_FLAGS /warn:0)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/csharp-tiger.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/code RENAME main)

install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/images)
install(FILES tiger.svg DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/images)

