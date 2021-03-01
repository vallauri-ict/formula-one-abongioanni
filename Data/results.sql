CREATE TABLE [Result] (
  [race_id] int,
  [driver_id] int,
  [team_id] int,
  [position] int,
  [points] int,
  [time] varchar(11),
  [laps_number] int,
  [fastest_lap] varchar(8),
  [start_position] int,
  [qualifying_time] varchar(8),
  [notes] varchar(255),
  PRIMARY KEY ([race_id], [driver_id])
);

CREATE TRIGGER [Trigger] 
	ON [dbo].[Result] 
	FOR DELETE, INSERT, UPDATE 
	AS 
BEGIN 
  DECLARE @pointsValue table (position int,points int) 
	INSERT INTO @pointsValue VALUES(1,25) 
	INSERT INTO @pointsValue VALUES(2,18) 
	INSERT INTO @pointsValue VALUES(3,15) 
	INSERT INTO @pointsValue VALUES(4,12) 
	INSERT INTO @pointsValue VALUES(5,10)  
	INSERT INTO @pointsValue VALUES(6,8) 
	INSERT INTO @pointsValue VALUES(7,6) 
	INSERT INTO @pointsValue VALUES(8,4) 
	INSERT INTO @pointsValue VALUES(9,2) 
	INSERT INTO @pointsValue VALUES(10,1) 
	INSERT INTO @pointsValue VALUES(11,0) 
	INSERT INTO @pointsValue VALUES(12,0) 
	INSERT INTO @pointsValue VALUES(13,0) 
	INSERT INTO @pointsValue VALUES(14,0) 
	INSERT INTO @pointsValue VALUES(15,0) 
	INSERT INTO @pointsValue VALUES(16,0)  
	INSERT INTO @pointsValue VALUES(17,0)  
	INSERT INTO @pointsValue VALUES(18,0)  
	INSERT INTO @pointsValue VALUES(19,0)  
	INSERT INTO @pointsValue VALUES(20,0) 

  DECLARE @teamId INT 
  DECLARE @driverId INT 
  DECLARE @raceId INT  
	DECLARE @position INT 
	DECLARE @points INT 

  SELECT @position=position,@raceId=race_id,@driverId=driver_id,@teamId=team_id FROM INSERTED 
  SELECT @points=points FROM @pointsValue WHERE position=@position 

  UPDATE [Result] 
  SET points=@points  
  WHERE race_id=@raceId AND driver_id=@driverId 

  IF EXISTS (select * from sysobjects where name='Driver' and xtype='U') 
  BEGIN
    IF (@position<4)
      UPDATE [Driver] 
      SET points=points+@points,podiums_number=podiums_number+1  
      WHERE [Driver].number=@driverId 
    ELSE
      UPDATE [Driver] 
      SET points=points+@points 
      WHERE [Driver].number=@driverId 
  END

  IF EXISTS (select * from sysobjects where name='Team' and xtype='U') 
    UPDATE [Team] 
    SET points=points+@points  
    WHERE [Team].id=@teamId 

  EXEC GenerateStats @driverId 
END; 

CREATE PROCEDURE [dbo].[GenerateStats] 
  @driverId INT 
AS 
  DECLARE @points INT 
  DECLARE @winCount INT 
  DECLARE @secondCount INT 
  DECLARE @thirdCount INT  
  DECLARE @fastCount INT 
  DECLARE @poleCount INT 
  DECLARE @pointsAvg FLOAT 

  IF NOT EXISTS (select * from sysobjects where name='Stats' and xtype='U') 
  BEGIN 
    CREATE TABLE [Stats] ( 
      [driver_id] INT PRIMARY KEY, 
      [points] INT,  
      [win_count] INT,  
      [second_count] INT, 
      [third_count] INT, 
      [fast_count] INT, 
      [pole_count] INT, 
      [points_avg] FLOAT, 
    )
  END 
  IF EXISTS (select * from sysobjects where name='Driver' and xtype='U') 
  BEGIN 
    SELECT @points=points FROM [Driver] WHERE [Driver].number=@driverId
    SELECT @winCount=COUNT(*) FROM [Result] WHERE [Result].driver_id=@driverId AND position=1 
    SELECT @secondCount=COUNT(*) FROM [Result] WHERE [Result].driver_id=@driverId AND position=2 
    SELECT @thirdCount=COUNT(*) FROM [Result] WHERE [Result].driver_id=@driverId AND position=3 
    SELECT @poleCount=COUNT(*) FROM [Result] WHERE [Result].driver_id=@driverId AND start_position=1 
    SELECT @fastCount=COUNT(*) 
    FROM [Result] 
      INNER JOIN (SELECT race_id,MIN(fastest_lap) fl FROM [Result] GROUP BY race_id) a ON a.race_id=[Result].race_id AND a.fl=[Result].fastest_lap 
    WHERE [Result].driver_id=@driverId 
      
    SELECT @pointsAvg=AVG(points) FROM [Result] WHERE [Result].driver_id=@driverId 
  END 
  IF EXISTS (select * from [Stats] WHERE driver_id=@driverId) 
  BEGIN 
    UPDATE [Stats] SET 
      points=@points, 
      win_count=@winCount, 
      second_count=@secondCount, 
      third_count=@thirdCount, 
      fast_count=@fastCount, 
      pole_count=@poleCount, 
      points_avg=@pointsAvg 
    WHERE driver_id=@driverId
  END 
  ELSE  
  BEGIN 
    INSERT INTO [Stats] VALUES( 
      @driverId, 
      @points, 
      @winCount, 
      @secondCount, 
      @thirdCount, 
      @fastCount, 
      @poleCount, 
      @pointsAvg 
    ) 
  END 
RETURN 0;


INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    5,
    77,
    1,
    '1:30:00:739',
    71,
    '1:07:475',
    1,
    '1:02:939',
    ' '
  );

INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    2,
    16,
    2,
    '1:30:02:739',
    71,
    '1:02:950',
    4,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    4,
    4,
    3,
    '1:30:04:739',
    71,
    '1:02:951',
    3,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    5,
    44,
    4,
    '1:30:06:739',
    71,
    '1:02:952',
    5,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    4,
    55,
    5,
    '1:30:08:739',
    71,
    '1:02:953',
    8,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    8,
    11,
    6,
    '1:30:10:739',
    71,
    '1:02:954',
    6,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    1,
    10,
    7,
    '1:30:12:739',
    71,
    '1:02:955',
    12,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    7,
    31,
    8,
    '1:30:14:739',
    71,
    '1:02:956',
    14,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    0,
    99,
    9,
    '1:30:15:739',
    71,
    '1:02:957',
    18,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    2,
    5,
    10,
    '1:30:16:739',
    71,
    '1:02:958',
    11,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    9,
    6,
    11,
    '1:30:18:739',
    71,
    '1:02:959',
    20,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    1,
    26,
    12,
    '1:30:20:739',
    69,
    '1:02:960',
    13,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    6,
    23,
    13,
    '1:30:22:739',
    67,
    '1:02:961',
    16,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    0,
    7,
    14,
    '1:30:23:739',
    53,
    '1:02:962',
    19,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    9,
    63,
    15,
    '1:30:24:739',
    49,
    '1:02:963',
    17,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    3,
    8,
    16,
    '1:30:25:739',
    49,
    '1:02:964',
    15,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    3,
    20,
    17,
    '1:30:26:739',
    24,
    '1:02:965',
    4,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    8,
    18,
    18,
    '1:30:30:739',
    20,
    '1:02:966',
    9,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    7,
    3,
    19,
    '1:30:32:739',
    17,
    '1:02:967',
    10,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    0,
    6,
    33,
    20,
    '1:30:33:739',
    11,
    '1:02:968',
    2,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    5,
    77,
    1,
    '1:30:00:739',
    71,
    '1:07:476',
    1,
    '1:02:939',
    ' '
  );

INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    2,
    16,
    2,
    '1:30:02:739',
    71,
    '1:02:970',
    4,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    4,
    4,
    3,
    '1:30:04:739',
    71,
    '1:02:911',
    3,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    5,
    44,
    4,
    '1:30:06:739',
    71,
    '1:02:922',
    5,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    4,
    55,
    5,
    '1:30:08:739',
    71,
    '1:02:933',
    8,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    8,
    11,
    6,
    '1:30:10:739',
    71,
    '1:02:932',
    6,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES 
  (
    1,
    1,
    10,
    7,
    '1:30:12:739',
    71,
    '1:02:945',
    12,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    7,
    31,
    8,
    '1:30:14:739',
    71,
    '1:02:934',
    14,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    0,
    99,
    9,
    '1:30:15:739',
    71,
    '1:02:988',
    18,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    2,
    5,
    10,
    '1:30:16:739',
    71,
    '1:02:912',
    11,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    9,
    6,
    11,
    '1:30:18:739',
    71,
    '1:02:999',
    20,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    1,
    26,
    12,
    '1:30:20:739',
    69,
    '1:02:913',
    13,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    6,
    23,
    13,
    '1:30:22:739',
    67,
    '1:02:914',
    16,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    0,
    7,
    14,
    '1:30:23:739',
    53,
    '1:02:915',
    19,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    9,
    63,
    15,
    '1:30:24:739',
    49,
    '1:02:916',
    17,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    3,
    8,
    16,
    '1:30:25:739',
    49,
    '1:02:917',
    15,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    3,
    20,
    17,
    '1:30:26:739',
    24,
    '1:02:918',
    4,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    8,
    18,
    18,
    '1:30:30:739',
    20,
    '1:02:919',
    9,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    7,
    3,
    19,
    '1:30:32:739',
    17,
    '1:02:920',
    10,
    '1:10:295',
    ' '
  );

  INSERT INTO
  [Result] (
    [race_id],
    [team_id],
    [driver_id],
    [position],
    [time],
    [laps_number],
    [fastest_lap],
    [start_position],
    [qualifying_time],
    [notes]
  )
VALUES
  (
    1,
    6,
    33,
    20,
    '1:30:33:739',
    11,
    '1:02:921',
    2,
    '1:10:295',
    ' '
  );