CREATE TABLE Teachers
(
	id INT NOT NULL IDENTITY(1,1),
	[name] NVARCHAR(128) NOT NULL,
	date_of_birth DATETIME2,
	hour_rate INT NOT NULL,
	fixed_salary FLOAT NOT NULL,
	CONSTRAINT Teachers_PK_1 PRIMARY KEY (id)
)