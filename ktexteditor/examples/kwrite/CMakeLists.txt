SET(SRC_KWRITEMAIN ${CMAKE_CURRENT_SOURCE_DIR}/kwritemain.cs)

SET(CS_FLAGS -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll 
-r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll 
-r:${LIBRARY_OUTPUT_PATH}/ktexteditor-dotnet.dll)

ADD_CS_EXECUTABLE(kwritemain ${SRC_KWRITEMAIN} ALL)
ADD_DEPENDENCIES(kwritemain ktexteditor-dotnet)

install(FILES kwrite-sharp.desktop DESTINATION ${XDG_APPS_INSTALL_DIR})
install(FILES kwrite-sharpui.rc DESTINATION ${DATA_INSTALL_DIR}/kwrite-sharp)
