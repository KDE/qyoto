SET(UI_CONTROLLER controller.ui)
ADD_CUSTOM_TARGET(ui_controller.cs ${UICS_PATH} ${UI_CONTROLLER} -o ui_controller.cs)

SET(SRC_CS_CONTROLLER main.cs  ui_controller.cs  controller.cs)
ADD_CUSTOM_TARGET (controller.exe ${GMCS_PATH} -unsafe -warn:0 -out:controller.exe -r:../../../../qt-dotnet.dll ${SRC_CS_CONTROLLER})

