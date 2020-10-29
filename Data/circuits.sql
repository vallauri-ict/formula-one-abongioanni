CREATE TABLE [dbo].[Circuit] (
    [circuitID] char(5) NOT NULL default '',
    [circuitName] varchar(70) NOT NULL default '',
    [countryCode] char(2) NOT NULL default '',
    [lapNumber] int NOT NULL default '',
    [turnNumber] int NOT NULL default '',
    [circuitLength] int NOT NULL,
    [firstGpHostYear] char(4) NOT NULL,
    [fastestLap] varchar(40) NOT NULL default '',
    [thumbnailImg] varchar(612) NOT NULL,
    [descIMG] varchar(612) NOT NULL,
    PRIMARY KEY ([circuitID])
);

INSERT INTO
    [Circuit]
VALUES
    (
        'RBR00',
        'Red Bull Ring',
        'AT',
        71,
        10,
        4318,
        '1970',
        '1:05.619-Carlos Sainz-2020',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Austria%20carbon.png.transform/8col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Austria_Circuit.png.transform/8col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'HUN00',
        'Hungaroring',
        'HU',
        70,
        14,
        4381,
        '1986',
        '1:17.103-Max Verstappen-2019',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Hungar%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Hungary_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'GBT00',
        'Silverstone Circuit',
        'GB',
        52,
        18,
        5891,
        '1950',
        '1:27.097-Max Verstappen-2020',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Great%20Britain%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Great_Britain_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'SPA00',
        'Silverstone Circuit',
        'ES',
        66,
        16,
        4655,
        '1991',
        '1:18.183-Valtteri Bottas-2020',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Spain%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Spain_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'BEL00',
        'Circuit de Spa-Francorchamps',
        'BE',
        44,
        19,
        7004,
        '1950',
        '1:46.286-Valtteri Bottas-2018',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Belgium%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Belgium_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'ITA00',
        'Autodromo Nazionale Monza',
        'IT',
        53,
        11,
        5793,
        '1950',
        '1:21.046-Rubens Barrichello-2004',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Italy%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Italy_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'ITA01',
        'Mugello',
        'IT',
        59,
        15,
        5245,
        '2020',
        '1:18.833-Lewis Hamilton-2020',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Tuscany%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Tuscany_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'RUS00',
        'Sochi Autodrom',
        'RU',
        53,
        18,
        5848,
        '2014',
        '1:35.761-Lewis Hamilton-2019',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Russi%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Russia_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'GER00',
        'Nürburgring',
        'DE',
        60,
        15,
        5148,
        '1951',
        '1:28.139-Max Verstappen-2020',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Germany%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Germany_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'POR00',
        'Autódromo Internacional do Algarve',
        'PT',
        66,
        15,
        4653,
        '2020',
        ' - - ',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Portugal%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Portugal_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'ITA02',
        'Autodromo Enzo e Dino Ferrari',
        'IT',
        63,
        21,
        4909,
        '1980',
        '1:20.411-Michael Schumacher-2004',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Emilia%20Romagna%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Emilia_Romagna_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'TUR00',
        'Intercity Istanbul Park',
        'TR',
        58,
        14,
        5338,
        '2005',
        '1:24.770-Juan Pablo Montoya-2005',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Turkey%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Turkey_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'BAH00',
        'Bahrain International Circuit',
        'BH',
        57,
        15,
        5412,
        '2004',
        '1:27.866-Charles Leclerc-2019',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Bahrain%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Bahrain_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'BAH01',
        'Bahrain International Circuit – Outer Track',
        'BH',
        87,
        11,
        3543,
        '2020',
        ' - - ',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Sakhir%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Sakhir_Circuit.png.transform/7col-retina/image.png'
    );

INSERT INTO
    [Circuit]
VALUES
    (
        'ABU01',
        'Yas Marina Circuit',
        'AE',
        55,
        21,
        5554,
        '2019',
        '1:39.283-Lewis Hamilton-2019',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Track%20icons%204x3/Abu%20Dhab%20carbon.png.transform/3col-retina/image.png',
        'https://www.formula1.com/content/dam/fom-website/2018-redesign-assets/Circuit%20maps%2016x9/Abu_Dhabi_Circuit.png.transform/7col-retina/image.png'
    );