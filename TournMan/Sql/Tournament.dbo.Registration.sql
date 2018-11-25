USE Tournament 
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[Registrations]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[Registrations]
END
GO
CREATE PROCEDURE
		 dbo.Registrations @TournamentId int = 0
AS
BEGIN
	select 
		t.*,
		tr.Amount,
		tour.Name as [TournamentName],
		tour.Location,
		tour.StartDate 
	from Tournament.dbo.Team t
	join Tournament.dbo.TournamentRegistration tr on tr.TeamId = t.ID
	join Tournament.dbo.Tournament tour on tour.Id = tr.TournamentId
	where tr.TournamentId = @TournamentId
END
GO