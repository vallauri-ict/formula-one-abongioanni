CREATE TABLE [dbo].[Driver]
(
	[id] int PRIMARY KEY IDENTITY(1,1),
	[HelmetImage] image NOT NULL,
	[FullImage] image NOT NULL,
	[FullName] varchar(100) NOT NULL default '',
	[Number] int UNIQUE NOT NULL,
	[TeamId] int NOT NULL,
	[Podiums] int NOT NULL,
	[CountryCode] char(2) NOT NULL ,
	[Dob] date,
);

INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\alexalbon-helmet.png',
		'C:\\data\\FormulaOne\\img\\alexalbon.jpg',
		'Alexander Albon',
		23,
		7,
		1,
		'TH',
		CONVERT(date,'1996-03-23')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\antonio-helmet.png',
		'C:\\data\\FormulaOne\\img\\antonio.png',
		'Antonio Giovinazzi',
		99,
		1,
		0,
		'IT',
		CONVERT(date,'1993-12-14')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\lewis-helmet.png',
		'C:\\data\\FormulaOne\\img\\lewis.jpg',
		'Lewis Hamilton',
		44,
		6,
		159,
		'GB',
		CONVERT(date,'1985-01-07')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\lando-helmet.png',
		'C:\\data\\FormulaOne\\img\\lando.jpg',
		'Lando Norris',
		4,
		5,
		1,
		'GB',
		CONVERT(date,'1999-11-13')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\georgerussel-helmet.png',
		'C:\\data\\FormulaOne\\img\\georgerussel.jpg',
		'George Russel',
		63,
		10,
		0,
		'GB',
		CONVERT(date,'1998-02-15')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\valtteri-helmet.png',
		'C:\\data\\FormulaOne\\img\\valtteri.jpg',
		'Valtteri Bottas',
		77,
		6,
		53,
		'FI',
		CONVERT(date,'1989-08-28')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\danil-helmet.png',
		'C:\\data\\FormulaOne\\img\\danil.jpg',
		'Danil Kvyat',
		26,
		2,
		3,
		'RU',
		CONVERT(date,'1994-04-26')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\ocon-helmet.png',
		'C:\\data\\FormulaOne\\img\\ocon.jpg',
		'Esteban Ocon',
		31,
		8,
		0,
		'FR',
		CONVERT(date,'1996-09-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\sainz-helmet.png',
		'C:\\data\\FormulaOne\\img\\sainz.jpg',
		'Carlos Sainz',
		55,
		5,
		2,
		'ES',
		CONVERT(date,'1994-09-01')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\pierre-helmet.png',
		'C:\\data\\FormulaOne\\img\\pierre.jpg',
		'Pierre Gasly',
		10,
		2,
		2,
		'FR',
		CONVERT(date,'1996-02-07')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\latifi-helmet.png',
		'C:\\data\\FormulaOne\\img\\latifi.jpg',
		'Nicholas Latifi',
		6,
		10,
		0,
		'CA',
		CONVERT(date,'1995-06-29')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\perez-helmet.png',
		'C:\\data\\FormulaOne\\img\\perez.jpg',
		'Sergio Perez',
		11,
		9,
		8,
		'MX',
		CONVERT(date,'1990-01-26')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\stroll-helmet.png',
		'C:\\data\\FormulaOne\\img\\stroll.jpg',
		'Lance Stroll',
		18,
		9,
		2,
		'CA',
		CONVERT(date,'1996-03-23')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\leclerc-helmet.png',
		'C:\\data\\FormulaOne\\img\\leclerc.jpg',
		'Charles Leclerc',
		16,
		3,
		12,
		'MC',
		CONVERT(date,'1997-10-16')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\kimi-helmet.png',
		'C:\\data\\FormulaOne\\img\\kimi.jpg',
		'Kimi Raikkonen',
		7,
		1,
		103,
		'FI',
		CONVERT(date,'1979-10-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\max-helmet.png',
		'C:\\data\\FormulaOne\\img\\max.jpg',
		'Max Verstappen',
		33,
		7,
		38,
		'NL',
		CONVERT(date,'1997-09-30')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\romain-helmet.png',
		'C:\\data\\FormulaOne\\img\\romain.jpg',
		'Romain Grosjean',
		8,
		4,
		10,
		'FR',
		CONVERT(date,'1986-04-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\magnussen-helmet.png',
		'C:\\data\\FormulaOne\\img\\magnussen.jpg',
		'Kevin Magnussen',
		20,
		4,
		1,
		'DK',
		CONVERT(date,'1992-10-05')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\daniel-helmet.png',
		'C:\\data\\FormulaOne\\img\\daniel.jpg',
		'Daniel Ricciardo',
		3,
		8,
		29,
		'AU',
		CONVERT(date,'1989-07-01')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\FormulaOne\\img\\seb-helmet.png',
		'C:\\data\\FormulaOne\\img\\seb.jpg',
		'Sebastian Vettel',
		5,
		3,
		120,
		'DE',
		CONVERT(date,'1987-07-03')
);