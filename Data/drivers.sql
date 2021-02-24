CREATE TABLE [Driver] (
	[number] int PRIMARY KEY,
	[full_name] varchar(100),
	[country] char(2) NOT NULL,
	[date_birth] date,
	[team_id] int,
	[podiums_number] int,
	[helmet_image] image,
	[full_image] image
);

INSERT INTO
	[Driver] (
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\alexalbon-helmet.png',
		'C:\\data\\FormulaOne\\img\\alexalbon.jpg',
		'Alexander Albon',
		23,
		6,
		1,
		'TH',
		CONVERT(date, '1996-03-23')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\antonio-helmet.png',
		'C:\\data\\FormulaOne\\img\\antonio.jpg',
		'Antonio Giovinazzi',
		99,
		0,
		0,
		'IT',
		CONVERT(date, '1993-12-14')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\lewis-helmet.png',
		'C:\\data\\FormulaOne\\img\\lewis.jpg',
		'Lewis Hamilton',
		44,
		5,
		159,
		'GB',
		CONVERT(date, '1985-01-07')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\lando-helmet.png',
		'C:\\data\\FormulaOne\\img\\lando.jpg',
		'Lando Norris',
		4,
		4,
		1,
		'GB',
		CONVERT(date, '1999-11-13')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\georgerussel-helmet.png',
		'C:\\data\\FormulaOne\\img\\georgerussel.jpg',
		'George Russel',
		63,
		9,
		0,
		'GB',
		CONVERT(date, '1998-02-15')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\valtteri-helmet.png',
		'C:\\data\\FormulaOne\\img\\valtteri.jpg',
		'Valtteri Bottas',
		77,
		5,
		53,
		'FI',
		CONVERT(date, '1989-08-28')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\danil-helmet.png',
		'C:\\data\\FormulaOne\\img\\danil.jpg',
		'Danil Kvyat',
		26,
		1,
		3,
		'RU',
		CONVERT(date, '1994-04-26')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\ocon-helmet.png',
		'C:\\data\\FormulaOne\\img\\ocon.jpg',
		'Esteban Ocon',
		31,
		7,
		0,
		'FR',
		CONVERT(date, '1996-09-17')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\sainz-helmet.png',
		'C:\\data\\FormulaOne\\img\\sainz.jpg',
		'Carlos Sainz',
		55,
		4,
		2,
		'ES',
		CONVERT(date, '1994-09-01')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\pierre-helmet.png',
		'C:\\data\\FormulaOne\\img\\pierre.jpg',
		'Pierre Gasly',
		10,
		1,
		2,
		'FR',
		CONVERT(date, '1996-02-07')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\latifi-helmet.png',
		'C:\\data\\FormulaOne\\img\\latifi.jpg',
		'Nicholas Latifi',
		6,
		9,
		0,
		'CA',
		CONVERT(date, '1995-06-29')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\perez-helmet.png',
		'C:\\data\\FormulaOne\\img\\perez.jpg',
		'Sergio Perez',
		11,
		8,
		8,
		'MX',
		CONVERT(date, '1990-01-26')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\stroll-helmet.png',
		'C:\\data\\FormulaOne\\img\\stroll.jpg',
		'Lance Stroll',
		18,
		8,
		2,
		'CA',
		CONVERT(date, '1996-03-23')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\leclerc-helmet.png',
		'C:\\data\\FormulaOne\\img\\leclerc.jpg',
		'Charles Leclerc',
		16,
		2,
		12,
		'MC',
		CONVERT(date, '1997-10-16')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\kimi-helmet.png',
		'C:\\data\\FormulaOne\\img\\kimi.jpg',
		'Kimi Raikkonen',
		7,
		0,
		103,
		'FI',
		CONVERT(date, '1979-10-17')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\max-helmet.png',
		'C:\\data\\FormulaOne\\img\\max.jpg',
		'Max Verstappen',
		33,
		6,
		38,
		'NL',
		CONVERT(date, '1997-09-30')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\romain-helmet.png',
		'C:\\data\\FormulaOne\\img\\romain.jpg',
		'Romain Grosjean',
		8,
		3,
		10,
		'FR',
		CONVERT(date, '1986-04-17')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\magnussen-helmet.png',
		'C:\\data\\FormulaOne\\img\\magnussen.jpg',
		'Kevin Magnussen',
		20,
		3,
		1,
		'DK',
		CONVERT(date, '1992-10-05')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\daniel-helmet.png',
		'C:\\data\\FormulaOne\\img\\daniel.jpg',
		'Daniel Ricciardo',
		3,
		7,
		29,
		'AU',
		CONVERT(date, '1989-07-01')
	);

INSERT INTO
	[Driver](
		[helmet_image],
		[full_image],
		[full_name],
		[number],
		[team_id],
		[podiums_number],
		[country],
		[date_birth]
	)
VALUES
(
		'C:\\data\\FormulaOne\\img\\seb-helmet.png',
		'C:\\data\\FormulaOne\\img\\seb.jpg',
		'Sebastian Vettel',
		5,
		2,
		120,
		'DE',
		CONVERT(date, '1987-07-03')
	);
