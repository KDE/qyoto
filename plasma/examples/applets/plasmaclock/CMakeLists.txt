project(cs-plasmaclock)
include(CSharpMacros)

set(UI_TIMEZONESCONFIG ${CMAKE_CURRENT_SOURCE_DIR}/timezonesConfig.ui)
add_custom_command(OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/ui_timezonesconfig.cs COMMAND ${UICS_EXECUTABLE} ${UI_TIMEZONESCONFIG} -o ui_timezonesconfig.cs COMMENT "Generating ui_timzonesconfig.cs")

set(SRC_PLASMACLOCK clockapplet.cs ${CMAKE_CURRENT_BINARY_DIR}/ui_timezonesconfig.cs)

set(CS_FLAGS -warn:0 "-r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll,${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll,${LIBRARY_OUTPUT_PATH}/plasma.dll")
add_cs_library(plasmaclock "${SRC_PLASMACLOCK}" ALL)
