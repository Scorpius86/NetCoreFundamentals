CREATE TABLE [dbo].[Conference] (
    [ConferenceId]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (250) NULL,
    [Start]    DATETIME2 (7)  NOT NULL,
    [Location] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED ([ConferenceId] ASC)
);

