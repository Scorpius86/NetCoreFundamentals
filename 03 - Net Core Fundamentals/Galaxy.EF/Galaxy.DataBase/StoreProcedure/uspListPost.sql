CREATE PROCEDURE [dbo].[uspListPost]
AS
	SELECT 
		[PostId]
		,[Titulo]
		,[Contenido]
		,[UsuarioIdPropietario]
		,[UsuarioIdCreacion]
		,[FechaCreacion]
		,[UsuarioIdActualizacion]
		,[FechaActualizacion]
		,[SysStartTime]
		,[SysEndTime]
	FROM [Post]