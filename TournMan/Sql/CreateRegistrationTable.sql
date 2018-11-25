USE Tournament
GO
CREATE TABLE TournamentRegistration(
        Id int not null identity primary key,
        TournamentId int not null,
        TeamId int not null,
        Amount decimal(18,2),
    Constraint FK_Tournament_Tournament Foreign key (TournamentId) 
        references Tournament.dbo.Tournament 
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    Constraint FK_Tournament_Team Foreign key (TeamId) 
        references Tournament.dbo.Team 
        on DELETE CASCADE 
        on update CASCADE)