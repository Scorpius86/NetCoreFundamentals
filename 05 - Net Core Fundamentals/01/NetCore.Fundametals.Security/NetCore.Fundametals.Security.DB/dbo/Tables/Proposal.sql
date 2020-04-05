CREATE TABLE [dbo].[Proposal] (
    [ProposalId]           INT            IDENTITY (1, 1) NOT NULL,
    [ConferenceId] INT            NOT NULL,
    [Speaker]      NVARCHAR (MAX) NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Approved]     BIT            NOT NULL,
    CONSTRAINT [PK_Proposal] PRIMARY KEY CLUSTERED ([ProposalId] ASC),
    CONSTRAINT [FK_Proposal_Conference] FOREIGN KEY ([ConferenceId]) REFERENCES [dbo].[Conference] ([ConferenceId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Proposal_ConferenceId]
    ON [dbo].[Proposal]([ConferenceId] ASC);

