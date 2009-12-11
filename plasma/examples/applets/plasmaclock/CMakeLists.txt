project(cs-plasmaclock)

set(UI_TIMEZONESCONFIG ${CMAKE_CURRENT_SOURCE_DIR}/timezonesConfig.ui)
add_custom_command(OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/ui_timezonesconfig.cs COMMAND ${UICS_EXECUTABLE} ${UI_TIMEZONESCONFIG} -o ui_timezonesconfig.cs COMMENT "Generating ui_timzonesconfig.cs")
set(UI_CALENDAR ${CMAKE_CURRENT_SOURCE_DIR}/calendar.ui)
add_custom_command(OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/calendar.cs COMMAND ${UICS_EXECUTABLE} ${UI_CALENDAR} -o calendar.cs COMMENT "Generating calendar.cs")

set(SRC_PLASMACLOCK clockapplet.cs ${CMAKE_CURRENT_BINARY_DIR}/ui_timezonesconfig.cs ${CMAKE_CURRENT_BINARY_DIR}/calendar.cs)

csharp_add_library(plasmaclock "${SRC_PLASMACLOCK}" REFERENCES qt-dotnet kde-dotnet plasma-dll COMPILE_FLAGS /warn:0)
