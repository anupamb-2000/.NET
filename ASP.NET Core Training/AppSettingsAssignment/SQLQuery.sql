USE [.NET-Training];

CREATE TABLE Students (
	Id INT IDENTITY,
	AdmsnNo INT,
	Name VARCHAR(250),
	Class INT,
	Address VARCHAR(500)
);

INSERT INTO [dbo].[Students]
           ([AdmsnNo]
           ,[Name]
           ,[Class]
           ,[Address])
     VALUES
		   (56,'Emmi',2,'4098 Parkside Lane'),
		   (259,'Michal',11,'4 Troy Court'),
		   (44,'Luke',12,'3 Basil Trail'),
		   (3594,'Nathan',10,'221B Bakers Street');



SELECT * FROM Students;