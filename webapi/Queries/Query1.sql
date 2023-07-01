IF NOT EXISTS
	(SELECT [name] FROM sys.databases WHERE [name] = 'CMPS_339_AmusementPark')
BEGIN
	CREATE DATABASE CMPS_339_AmusementPark
	PRINT('Database created.')
END

ELSE
BEGIN
	PRINT('Database already exists.')
END