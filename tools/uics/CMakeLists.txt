include_directories( ${CMAKE_CURRENT_SOURCE_DIR} )
include_directories( ${CMAKE_CURRENT_SOURCE_DIR}/cs )

########### next target ###############

set(uics_bin_SRCS 
   customwidgetsinfo.cpp 
   databaseinfo.cpp 
   driver.cpp 
   treewalker.cpp 
   ui4.cpp 
   uic.cpp 
   validator.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswritedeclaration.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswriteincludes.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswriteicondata.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswriteicondeclaration.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswriteiconinitialization.cpp 
   ${CMAKE_CURRENT_SOURCE_DIR}/cs/cswriteinitialization.cpp 
   main.cpp )

add_executable(uics_bin ${uics_bin_SRCS})
set_target_properties(uics_bin PROPERTIES OUTPUT_NAME uics)
set_target_properties(uics_bin PROPERTIES COMPILE_FLAGS -DQT_UIC_CS_GENERATOR)

target_link_libraries(uics_bin  ${QT_QTCORE_LIBRARY} ${QT_QTXML_LIBRARY} )

install(TARGETS uics_bin DESTINATION ${CMAKE_INSTALL_PREFIX}/bin)


########### next target ###############


########### install files ###############
