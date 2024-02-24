SELECT name, collation_name FROM sys.databases;
GO
ALTER DATABASE db_aa59a6_fjanjesic SET SINGLE_USER WITH
ROLLBACK IMMEDIATE;
GO
ALTER DATABASE db_aa59a6_fjanjesic COLLATE Croatian_CI_AS;
GO
ALTER DATABASE db_aa59a6_fjanjesic SET MULTI_USER;
GO
SELECT name, collation_name FROM sys.databases;
GO

create table INSTRUCTOR(
	ID int not null primary key identity (1,1),
	FIRST_NAME varchar (50),
	LAST_NAME varchar (50),
	PILOT_LICENSE_NUMBER varchar (50),
	EMAIL varchar (50),
	CONTACT_NUMBER varchar (20)
	);

create table DRONE(
	ID int not null primary key identity (1,1),
	TYPE varchar (25) not null,
	BRAND varchar (25),
	MODEL varchar (25),
	PURCHASE_DATE datetime,
	DATE_OF_REGISTRATION datetime
	);

create table COURSE(
	ID int not null primary key identity (1,1),
	ID_INSTRUCTOR int not null,
	ID_DRONE int not null,
	ID_CATEGORY int not null,
	START_DATE datetime not null
	);

create table STUDENT(
	ID int not null primary key identity (1,1),
	FIRST_NAME varchar (15) not null,
	LAST_NAME varchar (15) not null,
	ADDRESS varchar (50),
	OIB char (11) not null,
	CONTACT_NUMBER varchar (25) not null,
	DATE_OF_ENROLLMENT datetime not null,
	);

create table CATEGORY(
	ID int not null primary key identity (1,1),
	NAME varchar (50) not null,
	PRICE decimal not null,
	NUMBER_OF_TR_LECTURES varchar (50) not null,
	NUMBER_OF_FLYING_LECTURES varchar (50) not null
	);

create table STUDENT_COURSE(
	ID int not null primary key identity (1,1),
	ID_STUDENT int not null,
	ID_COURSE int not null
	);


	alter table COURSE add foreign key (ID_INSTRUCTOR) references INSTRUCTOR(ID);
	alter table COURSE add foreign key (ID_VEHICLE) references VEHICLE(ID);
	alter table COURSE add foreign key (ID_CATEGORY) references CATEGORY(ID);
	alter table STUDENT_COURSE add foreign key (ID_student) references STUDENT(ID);
	alter table STUDENT_COURSE add foreign key (ID_course) references COURSE(ID);


insert into INSTRUCTOR(FIRST_NAME,LAST_NAME,PILOT_LICENSE_NUMBER,EMAIL,CONTACT_NUMBER)
	values 
	('FILIP','JANJEŠIÆ','15373854444','janjesic@gmail.com','0919175470'),
	('MARKO','MARKOVIC','5496138811','markovic@gmail.com','0911111111'),
	('IVAN','IVIC','1423694511','ivic@gmail.com','0911111112'),
	('MARIJA','MARIJANOVIC','6966438211','marijanovic@gmail.com','0911111113');

insert into DRONE(TYPE,BRAND,MODEL,PURCHASE_DATE,DATE_OF_REGISTRATION)
	values
	('ENTERPRISE','Parrot','ANAFI Ai 4G','2022-06-05 00:00:00','2025-02-05 00:00:00'),
	('FPV','DJI','Avata Explorer Combo','2022-01-05 00:00:00','2025-01-02 00:00:00'),
	('LiDAR','DJI','Matrice 350 RTK','2021-11-09 00:00:00','2025-06-01 00:00:00'),
	('MULTISPECTRAL','Autel', 'Robotics Dragonfish','2023-10-15 00:00:00','2025-03-26 00:00:00');
	
insert into CATEGORY(NAME,PRICE,NUMBER_OF_TR_LECTURES,NUMBER_OF_FLYING_LECTURES)
values 
	('CAA General Visual Line of Sight (GVC) Course','1300','10','6'),
	('PfCO to GVC Conversion Course','500.50','5','35'),
	('A2 Certificate of Competence Course','400.75','18','25');

insert into STUDENT (FIRST_NAME, LAST_NAME, ADDRESS, OIB, CONTACT_NUMBER, DATE_OF_ENROLLMENT)
values
  ('Ana', 'Babiæ', 'Zagrebaèka 1', '12345678901', '0912345678', '2023-06-06 00:00:00'),
  ('Ivan', 'Kovaèiæ', 'Split 2', '23456789012', '0923456789', '2023-06-07 00:00:00'),
  ('Marija', 'Novak', 'Osijek 3', '34567890123', '0934567890', '2022-03-05 00:00:00'),
  ('Marko', 'Horvat', 'Rijeka 4', '45678901234', '0945678901', '2023-06-01 00:00:00'),
  ('Elena', 'Kneževiæ', 'Zadar 5', '56789012345', '0956789012', '2023-02-02 00:00:00'),
  ('Ante', 'Petroviæ', 'Sibenik 6', '67890123456', '0967890123', '2023-03-05 00:00:00'),
  ('Ana', 'Juriæ', 'Dubrovnik 7', '78901234567', '0978901234', '2022-12-05 00:00:00'),
  ('Ivan', 'Radiæ', 'Pula 8', '89012345678', '0989012345', '2022-12-01 00:00:00'),
  ('Petra', 'Matiæ', 'Varaždin 9', '90123456789', '0990123456', '2023-03-03 00:00:00'),
  ('Dario', 'Šimunoviæ', 'Sisak 10', '10987654321', '0911234567', '2022-12-12 00:00:00'),
  ('Jana', 'Kovaè', 'Pazin 11', '98765432101', '0922345678', '2023-01-21 00:00:00'),
  ('Luka', 'Vukoviæ', 'Vinkovci 12', '87654321012', '0933456789', '2023-01-31 00:00:00'),
  ('Sara', 'Blaževiæ', 'Bjelovar 13', '76543210123', '0944567890', '2023-03-08 00:00:00'),
  ('Ivan', 'Perkoviæ', 'Koprivnica 14', '65432101234', '0955678901', '2023-04-09 00:00:00'),
  ('Ema', 'Maras', 'Èakovec 15', '54321012345', '0966789012', '2023-04-21 00:00:00');

	
insert into COURSE(ID_INSTRUCTOR,ID_DRONE,ID_CATEGORY,START_DATE)
	values
		('1','1','1','2023-02-05 18:00:00'),
		('2','2','2','2023-01-12 17:00:00'),
		('3','3','3','2023-01-05 12:00:00'),	
		('4','4','4','2023-06-06 13:00:00');
