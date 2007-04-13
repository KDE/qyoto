SET(UI_CONTROLLER ${CMAKE_CURRENT_SOURCE_DIR}/controller.ui)
ADD_CUSTOM_TARGET(ui_controller.cs ALL ${UICS_PATH} ${UI_CONTROLLER} -o ui_controller.cs COMMENT "Building ui_controller.cs")

SET(SRC_CS_CONTROLLER ${CMAKE_CURRENT_SOURCE_DIR}/main.cs  ${CMAKE_CURRENT_BINARY_DIR}/ui_controller.cs  ${CMAKE_CURRENT_SOURCE_DIR}/controller.cs)
ADD_CUSTOM_TARGET (controller.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:controller.exe -r:../../../../qt-dotnet.dll ${SRC_CS_CONTROLLER} COMMENT "Building controller.exe")

ADD_DEPENDENCIES(controller.exe ui_controller.cs)
