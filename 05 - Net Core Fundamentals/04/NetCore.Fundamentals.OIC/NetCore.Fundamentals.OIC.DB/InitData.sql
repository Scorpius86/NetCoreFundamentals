INSERT INTO [dbo].[Conference]([Name],[Start],[Location])
     VALUES 
        ('.Net Core Fundamentals Security','2020-10-12 00:00:00.0000000','Hotel los delfines'),
        ('.Net Core Fundamentals Starter','2020-06-18 00:00:00.0000000','Centro de convenciones del hotel Sheraton');

INSERT INTO [dbo].[Attendee]([ConferenceId],[Name])
     VALUES
           (1,'Lisa Overthere'),
           (1,'Robin Eisenberg'),
           (2,'Sue Mashmellow');

INSERT INTO [dbo].[Proposal]([ConferenceId],[Speaker],[Title],[Approved])
     VALUES
           (1,'Erick Aróstegui Cunza','Authentication and Authorization in ASP.NET Core',1),
           (2,'Elmer Cangahuala Marquez','Starting Your Developer Career',0),
           (2,'Oscar Donayre Arótesgui','ASP.NET Core TagHelpers',0);
