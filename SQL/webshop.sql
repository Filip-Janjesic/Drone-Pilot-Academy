use master;
go

drop database if exists webshop;
go

create database webshop;
go

alter database webshop collate Croatian_CI_AS;
go

use webshop;

create table proizvodi (

	sifra int not null primary key identity(1,1),
	naslov varchar(50) not null,
	autor varchar(50) not null,
	cijena decimal(18,2) not null,
	sadrzaj text not null,
	vrijeme_kreiranja datetime not null,

);

create table korisnici (

	sifra int not null primary key identity(1,1),
	ime varchar(50) not null,
	prezime varchar(50) not null,
	lozinka varchar (60) not null,
	uloga varchar(50) not null,
	email varchar(100),
	vrijeme_registracije varchar(50) ,
	--potvrdite_email_token varchar(255),
	--reset_lozinke_token varchar(255),
	--upamtime_token varchar(255)
	
);

create table narudzbe(

	sifra int not null primary key identity(1,1),
	status_narudzbe varchar(50) not null,
	broj_narduzbe int not null,
	datum_narudzbe datetime not null,
	korisnik int not null
	
);

create table kupljeno(

	narudzbe int not null,
	proizvod int not null,
	cijena decimal(18,2),
	kolicina varchar(50)

);

alter table kupljeno add foreign key (narudzbe) references narudzbe(sifra);
alter table kupljeno add foreign key (proizvod) references proizvodi(sifra);
alter table narudzbe add foreign key (korisnik) references korisnici(sifra);

INSERT INTO proizvodi (naslov, autor, cijena, sadrzaj, vrijeme_kreiranja)
VALUES
('Proizvod 1', 'Autor 1', 24.99, 'Opis proizvoda 1', '2023-12-05'),
('Proizvod 2', 'Autor 2', 19.99, 'Opis proizvoda 2', '2023-12-06'),
('Proizvod 3', 'Autor 3', 12.50, 'Opis proizvoda 3', '2023-12-07');

INSERT INTO korisnici (ime, prezime, lozinka, uloga, email, vrijeme_registracije)
VALUES
('Filip', 'Janješić', '', 'Administrator', 'filip@gmail.com', '2023-12-06'),
('Ana', 'Anić', '', 'Kupac', 'ana@gmail.com', '2023-12-05'),
('Maja', 'Majić', '', 'Kupac', 'maja@gmail.com', '2023-12-07');

INSERT INTO narudzbe (status_narudzbe, broj_narduzbe, datum_narudzbe, korisnik)
VALUES
('Obrada', 15, '2023-12-08', 2),
('Isporučeno', 12, '2023-12-09', 3),
('Na čekanju', 20, '2023-12-10', 3);

INSERT INTO kupljeno (narudzbe, proizvod, cijena)
VALUES
(1, 1, 24.99),
(2, 3, 12.50),
(3, 2, 19.99);

