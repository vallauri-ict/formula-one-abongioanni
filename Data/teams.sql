CREATE TABLE [dbo].[Team]
(
	[id] int PRIMARY KEY IDENTITY(1,1),
	[SmallLogo] image NOT NULL default '',
	[FullLogo] image NOT NULL default '',
	[CarImage] image NOT NULL default '',
	[Color] varchar(100) NOT NULL default '',
	[SmallName] varchar(100) NOT NULL default '',
	[FullName] varchar(100) UNIQUE NOT NULL default '',
	[Base] varchar(100) NOT NULL default '',
	[TeamChief] varchar(100) NOT NULL default '',
	[PowerUnit] varchar(100) NOT NULL default '',
	[CountryCode] char(2) NOT NULL default '',
	[WorldChampionships] int default 0,
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\alfa-car.png',
		'C:\\data\\FormulaOne\\img\\alfa-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\alfa-team-smalllogo.png',
		'#960000',
		'Alfa Romeo Racing ORLEN',
		'Alfa Romeo',
		'Hinwil',
		'Frédéric Vasseur',
		'Ferrari',
		'CH',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\alphatauri-car.png',
		'C:\\data\\FormulaOne\\img\\alphatauri-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\alphatauri-team-smalllogo.png',
		'#FFFFFF',
		'Scuderia AlphaTauri Honda',
		'Alphatauri',
		'Faenza',
		'Franz Tost',
		'Honda',
		'IT',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\ferrari-car.png',
		'C:\\data\\FormulaOne\\img\\ferrari-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\ferrari-team-smalllogo.png',
		'#DC0000',
		'Scuderia Ferrari Mission Winnow',
		'Ferrari',
		'Maranello',
		'Mattia Binotto',
		'Ferrari',
		'IT',
		16       
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\haas-car.png',
		'C:\\data\\FormulaOne\\img\\haas-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\haas-team-smalllogo.png',
		'#787878',
		'Haas F1 Team',
		'Haas',
		'Kannapolis',
		'Guenther Steiner',
		'Ferrari',
		'US',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\mac-car.png',
		'C:\\data\\FormulaOne\\img\\mac-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\mac-team-smalllogo.png',
		'#FF8700',
		'McLaren F1 Team',
		'McLaren',
		'Woking',
		'Andreas Seidl',
		'Renault',
		'GB',
		8        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\mer-car.png',
		'C:\\data\\FormulaOne\\img\\mer-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\mer-team-smalllogo.png',
		'#00D2BE',
		'Mercedes-AMG Petronas F1 Team',
		'Mercedes',
		'Brackley',
		'Toto Wolff',
		'Mercedes',
		'GB',
		6       
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\red-car.png',
		'C:\\data\\FormulaOne\\img\\red-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\red-team-smalllogo.png',
		'#0600EF',
		'Aston Martin Red Bull Racing',
		'Red Bull Racing',
		'Milton Keynes',
		'Christian Horner',
		'Honda',
		'GB',
		4        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\ren-car.png',
		'C:\\data\\FormulaOne\\img\\ren-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\ren-team-smalllogo.png',
		'#FFF500',
		'Renault DP World F1 Team',
		'Renault',
		'Enstone',
		'Cyril Abiteboul',
		'Renault',
		'GB',
		2        
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\rp-car.png',
		'C:\\data\\FormulaOne\\img\\rp-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\rp-team-smalllogo.png',
		'#F596C8',
		'BWT Racing Point F1 Team',
		'Racing Point',
		'Silverstone',
		'Otmar Szafnauer',
		'Mercedes',
		'GB',
		0        
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\FormulaOne\\img\\williams-car.png',
		'C:\\data\\FormulaOne\\img\\williams-team-fulllogo.png',
		'C:\\data\\FormulaOne\\img\\williams-team-smalllogo.png',
		'#0082FA',
		'Williams Racing',
		'Williams',
		'Grove',
		'Simon Roberts',
		'Mercedes',
		'GB',
		9        
);