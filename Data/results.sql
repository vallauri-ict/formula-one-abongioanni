CREATE TABLE [Result] (
  [race_id] int,
  [driver_id] int,
  [team_id] int,
  [position] int,
  [time] varchar(8),
  [laps_number] int,
  [fastest_lap] varchar(6),
  [start_position] int,
  [qualifying_time] varchar(6),
  [notes] varchar(255),
  PRIMARY KEY ([race_id], [driver_id])
);