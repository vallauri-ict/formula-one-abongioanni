ALTER TABLE [Driver] ADD [FK_Drivers_Countries] FOREIGN KEY ([country]) REFERENCES [Country] ([iso2]);

ALTER TABLE [Team] ADD [FK_Teams_Countries] FOREIGN KEY ([country]) REFERENCES [Country] ([iso2]);

ALTER TABLE [Circuit] ADD [FK_Circuits_Countries] FOREIGN KEY ([country]) REFERENCES [Country] ([iso2]);

ALTER TABLE [Driver] ADD [FK_Teams_Drivers] FOREIGN KEY ([team_id]) REFERENCES [Team] ([id]);

ALTER TABLE [Race] ADD [FK_Race_Circuits] FOREIGN KEY ([circuit_id]) REFERENCES [Circuit] ([id]);

ALTER TABLE [Result] ADD [FK_Results_Teams] FOREIGN KEY ([team_id]) REFERENCES [Team] ([id]);

ALTER TABLE [Result] ADD [FK_Results_Drivers] FOREIGN KEY ([driver_id]) REFERENCES [Driver] ([number]);

ALTER TABLE [Result] ADD [FK_Results_Races] FOREIGN KEY ([race_id]) REFERENCES [Race] ([id]);

