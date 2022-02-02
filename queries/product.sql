drop table if exists Product;
go
create table Product(
	Id int primary key identity,
	Name varchar(64),
	Price int
)
go
insert into Product(Name, Price) values
('Kawa', 34),
('Herbata Czarna', 50),
('Herbata Zielona', 70),
('Pepsi', 30);
go
select * from Product;