SET(UI_CHATMAINWINDOW chatmainwindow.ui)
ADD_CUSTOM_TARGET(chatmainwindow.cs ALL ${UICS_PATH} ${UI_CHATMAINWINDOW} -o chatmainwindow.cs)

SET(UI_CHATSETNICKNAME chatsetnickname.ui)
ADD_CUSTOM_TARGET(chatsetnickname.cs ALL ${UICS_PATH} ${UI_CHATSETNICKNAME} -o chatsetnickname.cs)

SET(SRC_CS_CHAT chat_adaptor.cs  chat.cs  chat_interface.cs  chatmainwindow.cs  chatsetnickname.cs)
ADD_CUSTOM_TARGET (chat.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:chat.exe -r:../../../qt-dotnet.dll ${SRC_CS_CHAT})

