SET(SRC_EDITOR ${CMAKE_CURRENT_SOURCE_DIR}/editor.cs)

CSHARP_ADD_EXECUTABLE(editor ${SRC_EDITOR} REFERENCES qt-dotnet kde-dotnet ktexteditor-dotnet COMPILE_FLAGS /warn:0)
