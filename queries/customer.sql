drop Table if exists Customer;
go
create table Customer
(
	Id int primary key identity,
	FirstName varchar(64),
	LastName varchar(64),
	Email varchar(64),
	CreateAccount DateTime,
	AddressId int,
	Password varchar(128),
	Role varchar(64)
)
go
insert into Customer(FirstName,LastName,Email,CreateAccount,AddressId, Password, Role) values
('Jan','Kowalski','jankowalski@adress.email',GETDATE(),0,'1234','user'),
('Maria','Nowak','marian@mail.com',GETDATE(), 1,'1234','user'),
('Kuba','Karp','karpkuba@o2.pl',GETDATE(),2,'1234','user')

insert into Customer(FirstName,LastName,Email,CreateAccount, Password, Role) values
('Admin','Admin','admin@admin.com', GETDATE(), 'Admin123', 'admin');


select * from Customer;
go