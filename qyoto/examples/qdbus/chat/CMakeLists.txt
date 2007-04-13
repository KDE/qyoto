SET(UI_CHATMAINWINDOW chatmainwindow.ui)
ADD_CUSTOM_TARGET(chatmainwindow.cs ALL ${UICS_PATH} ${UI_CHATMAINWINDOW} -o chatmainwindow.cs COMMENT "Building chatmainwindow.cs")

SET(UI_CHATSETNICKNAME chatsetnickname.ui)
ADD_CUSTOM_TARGET(${CMAKE_CURRENT_SOURCE_DIR}/chatsetnickname.cs ALL ${UICS_PATH} ${UI_CHATSETNICKNAME} -o ${CMAKE_CURRENT_SOURCE_DIR}/chatsetnickname.cs COMMENT "Building ${CMAKE_CURRENT_SOURCE_DIR}/chatsetnickname.cs")

SET(SRC_CS_CHAT chat_${CMAKE_CURRENT_SOURCE_DIR}/adaptor.cs  ${CMAKE_CURRENT_SOURCE_DIR}/chat.cs  chat_${CMAKE_CURRENT_SOURCE_DIR}/interface.cs  ${CMAKE_CURRENT_SOURCE_DIR}/chatmainwindow.cs  ${CMAKE_CURRENT_SOURCE_DIR}/chatsetnickname.cs)
ADD_CUSTOM_TARGET (chat.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:chat.exe -r:../../../qt-dotnet.dll ${SRC_CS_CHAT} COMMENT "Building chat.exe")

ADD_DEPENDENCIES(chat.exe chatsetnickname.cs chatmainwindow.cs)
