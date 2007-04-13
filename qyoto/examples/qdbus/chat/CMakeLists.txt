SET(UI_CHATMAINWINDOW ${CMAKE_CURRENT_SOURCE_DIR}/chatmainwindow.ui)
ADD_CUSTOM_TARGET(chatmainwindow.cs ALL ${UICS_PATH} ${UI_CHATMAINWINDOW} -o chatmainwindow.cs COMMENT "Building chatmainwindow.cs")

SET(UI_CHATSETNICKNAME ${CMAKE_CURRENT_SOURCE_DIR}/chatsetnickname.ui)
ADD_CUSTOM_TARGET(chatsetnickname.cs ALL ${UICS_PATH} ${UI_CHATSETNICKNAME} -o chatsetnickname.cs COMMENT "Building chatsetnickname.cs")

SET(SRC_CS_CHAT ${CMAKE_CURRENT_SOURCE_DIR}/chat_adaptor.cs  ${CMAKE_CURRENT_SOURCE_DIR}/chat.cs  ${CMAKE_CURRENT_SOURCE_DIR}/chat_interface.cs  ${CMAKE_CURRENT_BINARY_DIR}/chatmainwindow.cs  ${CMAKE_CURRENT_BINARY_DIR}/chatsetnickname.cs)
ADD_CUSTOM_TARGET (chat.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:chat.exe -r:../../../qt-dotnet.dll ${SRC_CS_CHAT} COMMENT "Building chat.exe")

ADD_DEPENDENCIES(chat.exe chatsetnickname.cs chatmainwindow.cs)
