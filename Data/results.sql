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
		DECLARE @pointsValue table 
    (
        position int,
        points int
    )
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

  DECLARE @team_id INT 
	DECLARE @team_points INT 
  DECLARE @driver_id INT 
	DECLARE @driver_points INT 
  DECLARE @race_id INT  
	DECLARE @position INT 
	DECLARE @points INT

  SELECT @position=position,@race_id=race_id,@driver_id=driver_id FROM INSERTED
  SELECT @points=points FROM @pointsValue WHERE position=@position

  UPDATE [Result] 
  SET points=@points  
  WHERE race_id=@race_id AND driver_id=@driver_id 

	SELECT @driver_id = MIN( [Driver].number ) FROM [Driver] 

	WHILE(@driver_id IS NOT NULL) 
	BEGIN 
		SET @driver_points=0 
		SELECT @race_id = MIN(race_id) FROM Result WHERE driver_id=@driver_id 

		WHILE(@race_id IS NOT NULL) 
		BEGIN 
			SELECT @position=position FROM Result WHERE race_id=@race_id AND driver_id=@driver_id 

			SELECT @points=points FROM @pointsValue WHERE position=@position 
			SET @driver_points= @driver_points+@points 
 
			SELECT @race_id = MIN( race_id ) FROM Result WHERE race_id>@race_id AND driver_id=@driver_id 
		END 
		
		UPDATE [Driver] SET points=@driver_points WHERE [Driver].number=@driver_id 

 		SELECT @driver_id = MIN( [Driver].number ) FROM [Driver] WHERE [Driver].number>@driver_id 
	END 


	SELECT @team_id = MIN( [Team].id ) FROM [Team] 

	WHILE(@team_id IS NOT NULL) 
	BEGIN 
		SET @team_points=0 
		SELECT @race_id = MIN(race_id) FROM Result WHERE team_id=@team_id 

		WHILE(@race_id IS NOT NULL) 
		BEGIN 
    	SELECT @driver_id = MIN(driver_id) FROM Result WHERE team_id=@team_id AND race_id=@race_id 
    	WHILE(@driver_id IS NOT NULL) 
		  BEGIN 
        SELECT @position=position FROM Result WHERE race_id=@race_id AND driver_id=@driver_id  AND team_id=@team_id

        SELECT @points=points FROM @pointsValue WHERE position=@position 
        SET @team_points= @team_points+@points 

        SELECT @driver_id = MIN(driver_id) FROM Result WHERE team_id=@team_id AND race_id=@race_id AND driver_id>@driver_id
      END

      SELECT @race_id = MIN( race_id ) FROM Result WHERE race_id>@race_id AND team_id=@team_id 
		END 
		
		UPDATE [Team] SET points=@team_points WHERE [Team].id=@team_id 

 		SELECT @team_id = MIN( [Team].id ) FROM [Team] WHERE [Team].id>@team_id 
	END 
END; 

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
  )

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
    '1:02:951',
    4,
    '1:10:295',
    ' '
  )
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
  )
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
    '1:02:951',
    5,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    8,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    6,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    12,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    14,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    18,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    11,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    20,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    13,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    16,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    19,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    17,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    15,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    4,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    9,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    10,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    2,
    '1:10:295',
    ' '
  )

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
    '1:07:475',
    1,
    '1:02:939',
    ' '
  )

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
    '1:02:951',
    4,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    3,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    5,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    8,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    6,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    12,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    14,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    18,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    11,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    20,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    13,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    16,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    19,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    17,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    15,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    4,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    9,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    10,
    '1:10:295',
    ' '
  )
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
    '1:02:951',
    2,
    '1:10:295',
    ' '
  )