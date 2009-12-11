project(cs-analog-clock)

set(UI_CLOCKCONFIG ${CMAKE_CURRENT_SOURCE_DIR}/clockConfig.ui)
add_custom_command(OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/ui_clockconfig.cs COMMAND ${UICS_EXECUTABLE} ${UI_CLOCKCONFIG} -o ui_clockconfig.cs COMMENT "Generating ui_clockconfig.cs")

set(SRC_ANALOGCLOCK clock.cs ${CMAKE_CURRENT_BINARY_DIR}/ui_clockconfig.cs)

csharp_add_library(analog-clock "${SRC_ANALOGCLOCK}" REFERENCES qt-dotnet kde-dotnet plasma-dll plasmaclock COMPILE_FLAGS /warn:0)

file(MAKE_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp-analog-clock/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/plasmaclock.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-analog-clock/contents/code)
install(FILES ${LIBRARY_OUTPUT_PATH}/analog-clock.dll DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-analog-clock/contents/code RENAME main)
install(FILES metadata.desktop DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/csharp-analog-clock)
