IF EXISTS (SELECT 1
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE='BASE TABLE'
    AND TABLE_NAME='Country') 

SELECT "Country table exists" AS res ELSE SELECT "Country table doesn't exist" AS res;

IF EXISTS (SELECT 1
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE='BASE TABLE'
    AND TABLE_NAME='Team') 

SELECT "Team table exists" AS res ELSE SELECT "Team table doesn't exist" AS res;

IF EXISTS (SELECT 1
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE='BASE TABLE'
    AND TABLE_NAME='Team') 

SELECT "Driver table exists" AS res ELSE SELECT "Driver table doesn't exist" AS res;
