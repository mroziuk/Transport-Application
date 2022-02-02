drop table if exists Address;
go
create table Address
(
	Id int primary key identity,
	Country varchar(64),
	City varchar(64),
	Street varchar(64),
	Number int
)
insert into Address(Country,City,Street,Number) values
('Polska','Wrocaw','Krakowska',123),
('Polska','Krakow','Warszawska',43),
('Polska','Warszawa','Wroc³awska',8);
go
select * from Address;
