SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/src/SmokeInvocationKDE.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kde/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kio/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kparts/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/sonnet/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kns/*.cs)

# ADD_CUSTOM_TARGET (kde-dotnet ALL ${GMCS_PATH} -define:DEBUG -unsafe -warn:0 -out:kde-dotnet.dll -target:library ${SRC_CS}
#	COMMENT "Building kde-dotnet.dll")

SET(CS_FLAGS -debug -define:DEBUG -unsafe -warn:0 -r:${LIBRARY_OUTPUT_PATH}/qt-dotnet.dll)
ADD_CS_LIBRARY(kde-dotnet "${SRC_CS}" ALL)
ADD_DEPENDENCIES (kde-dotnet qt-dotnet)
#ADD_DEPENDENCIES (kde-dotnet ../qyoto/qt-dotnet)
#INSTALL(TARGETS kde-dotnet LIBRARY DESTINATION lib)


