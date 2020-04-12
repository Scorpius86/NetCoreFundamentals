CREATE TABLE [dbo].[Attendee] (
    [AttendeeId]           INT            IDENTITY (1, 1) NOT NULL,
    [ConferenceId] INT            NOT NULL,
    [Name]         NVARCHAR (250) NULL,
    CONSTRAINT [PK_Attendee] PRIMARY KEY CLUSTERED ([AttendeeId] ASC),
    CONSTRAINT [FK_Attendee_Conference] FOREIGN KEY ([ConferenceId]) REFERENCES [dbo].[Conference] ([ConferenceId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Attendee_ConferenceId]
    ON [dbo].[Attendee]([ConferenceId] ASC);

