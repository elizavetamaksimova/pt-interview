CREATE TABLE Lessons
(
	id INT NOT NULL IDENTITY(1,1),
	course_id INT NOT NULL,
	teacher_id INT NOT NULL,
	lesson_date DATETIME2 NOT NULL,
	CONSTRAINT Lessons_PK_1 PRIMARY KEY (id),
	CONSTRAINT Lessons_FK_1 FOREIGN KEY (course_id) REFERENCES Courses(id),
	CONSTRAINT Lessons_FK_2 FOREIGN KEY (teacher_id) REFERENCES Teachers(id),
)