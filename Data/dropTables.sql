IF EXISTS(
    SELECT
        *
    FROM
        [Team]
) DROP TABLE [Team];

IF EXISTS(
    SELECT
        *
    FROM
        [Driver]
) DROP TABLE [Driver];

IF EXISTS(
    SELECT
        *
    FROM
        [Country]
) DROP TABLE [Country];

IF EXISTS(
    SELECT
        *
    FROM
        [Circuit]
) DROP TABLE [Circuit];

IF EXISTS(
    SELECT
        *
    FROM
        [Race]
) DROP TABLE [Race];

DROP TABLE [Result];

IF EXISTS(
    SELECT
        *
    FROM
        [Stats]
) DROP TABLE [Stats];

IF object_id('GenerateStats') IS NOT NULL DROP PROCEDURE [GenerateStats];