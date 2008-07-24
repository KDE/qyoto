SET(SRC_EDITOR ${CMAKE_CURRENT_SOURCE_DIR}/editor.cs)

SET(CS_FLAGS -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll 
-r:${LIBRARY_OUTPUT_PATH}/kde-dotnet.dll 
-r:${LIBRARY_OUTPUT_PATH}/ktexteditor-dotnet.dll)

ADD_CS_EXECUTABLE(editor ${SRC_EDITOR} ALL)
