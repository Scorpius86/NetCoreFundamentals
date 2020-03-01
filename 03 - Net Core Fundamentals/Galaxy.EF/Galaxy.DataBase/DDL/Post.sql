CREATE TABLE [dbo].[Post]
(
	PostId INT NOT NULL IDENTITY,
	Titulo VARCHAR(200) NOT NULL,
	Contenido VARCHAR(MAX) NULL,	
	UsuarioIdPropietario INT NOT NULL,
	UsuarioIdCreacion INT NOT NULL,
	FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
	UsuarioIdActualizacion INT NOT NULL,
	FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
	
	SysStartTime datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    SysEndTime datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime),

	CONSTRAINT PK_Post PRIMARY KEY (PostId),

	CONSTRAINT FK_PostUsuarioPropietario FOREIGN KEY (UsuarioIdPropietario) REFERENCES Usuario(UsuarioId),
	CONSTRAINT FK_PostUsuarioCreacion FOREIGN KEY (UsuarioIdCreacion) REFERENCES Usuario(UsuarioId),
	CONSTRAINT FK_PostUsuarioActualizacion FOREIGN KEY (UsuarioIdActualizacion) REFERENCES Usuario(UsuarioId),
)
WITH    
(   
    SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.PostHistoria)   
)   