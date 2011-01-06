set(QYOTO_EXAMPLE ${CMAKE_INSTALL_PREFIX}/share/qyoto/cmake/QyotoExport.cmake)
set(QYOTO_INCLUDE_DIR ${CMAKE_INSTALL_PREFIX}/include/qyoto)
set(QYOTO_KEYFILE ${CMAKE_INSTALL_PREFIX}/share/qyoto/key.snk)
set(QYOTO_CMAKE_DIR ${CMAKE_INSTALL_PREFIX}/share/qyoto/cmake)
set(QYOTO_LIBRARY_DIR ${CMAKE_INSTALL_PREFIX}/lib)

get_property(QYOTO_ASSEMBLY TARGET qt-dotnet PROPERTY _assembly_destination)

if (TARGET qtscript)
    get_property(QTSCRIPT_ASSEMBLY TARGET qtscript PROPERTY _assembly_destination)
endif (TARGET qtscript)

if (TARGET qtuitools)
    get_property(QTUITOOLS_ASSEMBLY TARGET qtuitools PROPERTY _assembly_destination)
endif (TARGET qtuitools)

if (TARGET qttest)
    get_property(QTTEST_ASSEMBLY TARGET qttest PROPERTY _assembly_destination)
endif (TARGET qttest)

if (TARGET qtwebkit)
    get_property(QTWEBKIT_ASSEMBLY TARGET qtwebkit PROPERTY _assembly_destination)
endif (TARGET qtwebkit)

if (TARGET qscintilla)
    get_property(QSCINTILLA_ASSEMBLY TARGET qscintilla PROPERTY _assembly_destination)
endif (TARGET qscintilla)

if (TARGET phonon)
    get_property(PHONON_ASSEMBLY TARGET phonon PROPERTY _assembly_destination)
endif (TARGET phonon)

configure_file(${CMAKE_CURRENT_SOURCE_DIR}/QyotoConfig.cmake.in ${CMAKE_CURRENT_BINARY_DIR}/QyotoConfig.cmake @ONLY)

install(FILES CMakeCSharpCompiler.cmake.in
            CMakeCSharpInformation.cmake
            CMakeDetermineCSharpCompiler.cmake
            CMakeTestCSharpCompiler.cmake
            FindMono.cmake
            ${CMAKE_CURRENT_BINARY_DIR}/QyotoConfig.cmake
        DESTINATION share/qyoto/cmake )
