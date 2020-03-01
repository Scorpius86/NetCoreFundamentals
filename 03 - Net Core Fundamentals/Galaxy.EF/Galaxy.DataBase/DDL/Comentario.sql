CREATE TABLE [dbo].[Comentario]
(
	ComentarioId INT NOT NULL IDENTITY,
	PostId INT NOT NULL,
	Contenido VARCHAR(MAX) NULL,	
	UsuarioIdPropietario INT NOT NULL,
	UsuarioIdCreacion INT NOT NULL,
	FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
	UsuarioIdActualizacion INT NOT NULL,
	FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	
	SysStartTime datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    SysEndTime datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime),

	CONSTRAINT PK_Comentario PRIMARY KEY (ComentarioId),

	CONSTRAINT FK_ComentarioPost FOREIGN KEY (PostId) REFERENCES Post(PostId),
	CONSTRAINT FK_ComentarioUsuarioPropietario FOREIGN KEY (UsuarioIdPropietario) REFERENCES Usuario(UsuarioId),
	CONSTRAINT FK_ComentarioUsuarioCreacion FOREIGN KEY (UsuarioIdCreacion) REFERENCES Usuario(UsuarioId),
	CONSTRAINT FK_ComentarioUsuarioActualizacion FOREIGN KEY (UsuarioIdActualizacion) REFERENCES Usuario(UsuarioId),
)
WITH    
(   
    SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.ComentarioHistoria)   
)   