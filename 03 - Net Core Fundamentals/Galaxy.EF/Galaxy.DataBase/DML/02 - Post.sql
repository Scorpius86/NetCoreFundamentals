INSERT INTO [dbo].[Post]
           ([Titulo]
           ,[Contenido]
		   ,[UsuarioIdPropietario]
           ,[UsuarioIdCreacion]
           ,[FechaCreacion]
           ,[UsuarioIdActualizacion]
           ,[FechaActualizacion])
     VALUES
           ('Base de datos, tablas y carga de datos','Principios y modelado de datos',1,1,GETDATE(),1,GETDATE()),
		   ('Microservices','The term "Microservice Architecture" has sprung up over the last few years to describe a particular way of designing software applications as suites of independently deployable services. While there is no precise definition of this architectural style, there are certain common characteristics around organization around business capability, automated deployment, intelligence in the endpoints, and decentralized control of languages and data.',2,2,GETDATE(),2,GETDATE()),
		   ('Steve Jobs, padre de una era','Steve Jobs, el inventor del iPhone y el iPad, había renunciado a su trono en Apple debido a sus problemas de salud. Historia de un hombre que cambió la vida de las personas.',3,3,GETDATE(),3,GETDATE());