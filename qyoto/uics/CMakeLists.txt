
include_directories( ${CMAKE_SOURCE_DIR}/uics/cs/ )
########### next target ###############

set(uics_bin_SRCS 
   customwidgetsinfo.cpp 
   databaseinfo.cpp 
   driver.cpp 
   treewalker.cpp 
   ui4.cpp 
   uic.cpp 
   validator.cpp 
   cs/cswritedeclaration.cpp 
   cs/cswriteicondata.cpp 
   cs/cswriteicondeclaration.cpp 
   cs/cswriteiconinitialization.cpp 
   cs/cswriteinitialization.cpp 
   main.cpp )

kde4_automoc(${uics_bin_SRCS})

kde4_add_executable(uics_bin ${uics_bin_SRCS})
set_target_properties(uics_bin PROPERTIES OUTPUT_NAME uics)

target_link_libraries(uics_bin  ${KDE4_KDECORE_LIBS} )

install(TARGETS uics_bin DESTINATION ${BIN_INSTALL_DIR})


########### next target ###############


########### install files ###############


