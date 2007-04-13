SET(SIMPLETREEMODEL_QRC ${CMAKE_CURRENT_SOURCE_DIR}/simpletreemodel.qrc)
ADD_CUSTOM_TARGET (qrc_simpletreemodel.cs ALL ${CSRCC_PATH} -name simpletreemodel ${SIMPLETREEMODEL_QRC} -o qrc_simpletreemodel.cs COMMENT "Building qrc_simpletreemodel.cs")

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/main.cs ${CMAKE_CURRENT_SOURCE_DIR}/treemodel.cs ${CMAKE_CURRENT_SOURCE_DIR}/treeitem.cs ${CMAKE_CURRENT_BINARY_DIR}/qrc_simpletreemodel.cs)
ADD_CUSTOM_TARGET (simpletreemodel.exe ALL ${GMCS_PATH} -unsafe -warn:0 -out:simpletreemodel.exe -r:../../../qt-dotnet.dll ${SRC_CS} COMMENT "Building simpletreemodel.exe")

ADD_DEPENDENCIES (simpletreemodel.exe qrc_simpletreemodel.cs)
