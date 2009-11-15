SET(SIMPLETREEMODEL_QRC ${CMAKE_CURRENT_SOURCE_DIR}/simpletreemodel.qrc)
ADD_CUSTOM_COMMAND (OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/qrc_simpletreemodel.cs COMMAND ${CSRCC_EXECUTABLE} -name simpletreemodel ${SIMPLETREEMODEL_QRC} -o qrc_simpletreemodel.cs COMMENT "Generating qrc_simpletreemodel.cs")

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/main.cs ${CMAKE_CURRENT_SOURCE_DIR}/treemodel.cs ${CMAKE_CURRENT_SOURCE_DIR}/treeitem.cs ${CMAKE_CURRENT_BINARY_DIR}/qrc_simpletreemodel.cs)
SET(CS_FLAGS -unsafe -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll)
ADD_CS_EXECUTABLE (simpletreemodel "${SRC_CS}" ALL)
ADD_DEPENDENCIES(simpletreemodel qt-dotnet)
