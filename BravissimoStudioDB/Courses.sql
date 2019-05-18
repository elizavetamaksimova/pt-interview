CREATE TABLE Courses
(
	id INT NOT NULL IDENTITY(1,1),
	[name] NVARCHAR(128) NOT NULL,
	start_time TIME,
	end_time TIME,
	coefficient FLOAT NOT NULL,
	CONSTRAINT Courses_PK_1 PRIMARY KEY (id) 
)

