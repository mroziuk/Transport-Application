drop Table if exists Customer;
go
create table Customer
(
	Id int primary key identity,
	FullName varchar(64),
	Email varchar(64),
	CreateAccount DateTime,
	AddressId int
)
go
insert into Customer(FullName,Email,CreateAccount,AddressId) values
('Jan Kowalski','jankowalski@adress.email',GETDATE(),0),
('Maria Nowak','marian@mail.com',GETDATE(), 1),
('Kuba Karp','karpkuba@o2.pl',GETDATE(),2);


select * from Customer;
go