create table Roles(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	[Name] ntext
)

insert into Roles([Name]) values('User'),('Admin')

create Table Users(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	FullName ntext not null,
	Email ntext not null,
	[Password] ntext not null,
	IsActive int not null,
	UserRoleId int not null,
)

insert into Users(FullName,Email,Password,IsActive,UserRoleId)
values('admin','admin@mail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',1,2), 
('user','user@mail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',1,1)

create Table Genres(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Title ntext not null,
)

insert into Genres(Title) values('Math'),('Coding')


create Table Tests(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	GenreId int not null,
	Title ntext not null,
	Difficulty int not null,
)

insert into Tests(GenreId,Title,Difficulty)values
(1,'Basic Math',3),
(2,'Algorithms and Data Structures',8)

create Table Questions(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	TestId int not null,
	Title ntext not null,
	Score int not null,
)

insert into Questions(TestId,Title,Score)values
(1,'1 + 1',3),
(1,'2 + 4',5)

create Table TestResults(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	UserId int not null,
	TestId int not null,
	Result int not null,
)

select * from Questions

create Table Answers(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	QuestionId int not null,
	Title ntext not null,
	Correct int not null,
)

insert into Answers(QuestionId,Title,Correct) values
(1,'2',1),
(1,'3',0),
(1,'4',0),
(2,'6',1),
(2,'43',0)