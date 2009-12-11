SET(SRC_KWRITEMAIN ${CMAKE_CURRENT_SOURCE_DIR}/kwritemain.cs)

CSHARP_ADD_EXECUTABLE(kwritemain ${SRC_KWRITEMAIN} REFERENCES qt-dotnet kde-dotnet ktexteditor-dotnet COMPILE_FLAGS /warn:0)

install(FILES kwrite-sharp.desktop DESTINATION ${XDG_APPS_INSTALL_DIR})
install(FILES kwrite-sharpui.rc DESTINATION ${DATA_INSTALL_DIR}/kwrite-sharp)
