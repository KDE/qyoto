SET(SIMPLETREEMODEL_QRC ${CMAKE_CURRENT_SOURCE_DIR}/simpletreemodel.qrc)
ADD_CUSTOM_COMMAND (OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/qrc_simpletreemodel.cs COMMAND ${CSRCC_EXECUTABLE} -name simpletreemodel ${SIMPLETREEMODEL_QRC} -o qrc_simpletreemodel.cs COMMENT "Generating qrc_simpletreemodel.cs")

SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/main.cs ${CMAKE_CURRENT_SOURCE_DIR}/treemodel.cs ${CMAKE_CURRENT_SOURCE_DIR}/treeitem.cs ${CMAKE_CURRENT_BINARY_DIR}/qrc_simpletreemodel.cs)
CSHARP_ADD_EXECUTABLE (simpletreemodel "${SRC_CS}" REFERENCES qt-dotnet COMPILE_FLAGS /warn:0 UNSAFE)
ADD_DEPENDENCIES(simpletreemodel qt-dotnet)
