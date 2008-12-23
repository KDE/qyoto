project(cs-tiger)
include(CSharpMacros)

set(SRC_TIGER tiger.cs)

set(CS_FLAGS -warn:0 "-r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll,${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll,${LIBRARY_OUTPUT_PATH}/plasma-dll.dll")
add_cs_library(csharp-tiger "${SRC_TIGER}" ALL)

add_dependencies(csharp-tiger plasma-dll)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/csharp-tiger.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/code RENAME main)

install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/contents/images)
install(FILES tiger.svg DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-tiger/images)

