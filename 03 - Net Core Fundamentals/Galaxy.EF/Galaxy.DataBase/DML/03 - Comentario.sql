INSERT INTO [dbo].[Comentario]
           ([PostId]
		   ,[Contenido]
           ,[UsuarioIdPropietario]
           ,[UsuarioIdCreacion]
           ,[FechaCreacion]
           ,[UsuarioIdActualizacion]
           ,[FechaActualizacion])
     VALUES
           (1,'Test',1,1,GETDATE(),1,GETDATE()),
		   (2,'Test',1,1,GETDATE(),1,GETDATE()),
		   (3,'Test',1,1,GETDATE(),1,GETDATE());