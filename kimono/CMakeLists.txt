SET(SRC_CS ${CMAKE_CURRENT_SOURCE_DIR}/dom/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kde/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kio/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/kparts/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src/SmokeInvocation.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src/SmokeMarshallers.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src/Qyoto.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/src/QyotoMetaData.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/core/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/gui/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/network/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/sql/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/xml/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/svg/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/opengl/*.cs
	${CMAKE_CURRENT_SOURCE_DIR}/../qyoto/qdbus/*.cs)

# ADD_CUSTOM_TARGET (kde-dotnet ALL ${GMCS_PATH} -define:DEBUG -unsafe -warn:0 -out:kde-dotnet.dll -target:library ${SRC_CS}
#	COMMENT "Building kde-dotnet.dll")

SET(CS_FLAGS -debug -define:DEBUG -unsafe -warn:0)
ADD_CS_LIBRARY(kde-dotnet "${SRC_CS}" ALL)
#ADD_DEPENDENCIES (kde-dotnet ../qyoto/qt-dotnet)
#ADD_DEPENDENCIES (kde-dotnet kimono)
#INSTALL(TARGETS kde-dotnet LIBRARY DESTINATION lib)


