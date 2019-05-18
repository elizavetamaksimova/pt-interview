/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Courses(name, start_time, end_time, coefficient) VALUES 
	('A1 Mattina', '09:00', '11:00', 1.1),
	('A1 Sera', '19:00', '21:00', 1.1),
	('A2 Grammatica', '13:00', '14:00', 1.5),
	('B2 con italiano vero', '10:00', '12:00', 2),
	('C1 club del libro', '10:00', '12:00', 1.3),
	('B1 club del libro', '10:00', '12:00', 1.1),
	('B2 Conguntivo Mattina', '09:00', '11:00', 2.1),
	('B2 Conguntivo Sera', '19:00', '21:00', 2.1)

INSERT INTO Teachers(name, date_of_birth, hour_rate, fixed_salary) VALUES
    ('Luigi Giovanotto', '1980-05-21', 150, 1500),
	('Larisa Petrova', '1982-06-01', 100, 1000),
	('Lucrezia Oddone', '1990-01-08', 140, 1300),
	('Viktor Krasnov', '1960-11-15', 200, 1600),
	('Francesco Sforza', '1988-02-29', 170, 1650)

INSERT INTO Lessons (course_id, teacher_id, lesson_date) VALUES
	(1, 2, '2019-04-05'),
	(2, 3, '2019-04-04'),
	(6, 3, '2019-04-06'),
	(1, 2, '2019-04-07'),	
	(3, 1, '2019-04-07'),
	(2, 3, '2019-04-08'),
	(3, 1, '2019-04-08'),
	(3, 1, '2019-04-09'),
	(3, 1, '2019-04-10'),
	(2, 3, '2019-04-10'),
	(1, 2, '2019-04-10'),
	(3, 3, '2019-04-08'),
	(5, 4, '2019-04-14'),
	(1, 2, '2019-04-15'),
	(1, 2, '2019-04-18'),
	(5, 4, '2019-04-18'),
	(2, 3, '2019-04-18'),
	(1, 2, '2019-04-20'),
	(2, 3, '2019-04-20'),
	(5, 4, '2019-04-22'),
	(1, 4, '2019-04-23'),
	(6, 4, '2019-04-24'),
	(7, 4, '2019-04-25'),
	(8, 4, '2019-04-26'),
	(7, 4, '2019-04-27'),
	(8, 4, '2019-04-28'),	
	(7, 4, '2019-04-29'),
	(8, 4, '2019-04-30'),
	(8, 4, '2019-04-30')