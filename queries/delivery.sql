drop table if exists Delivery;
go
drop table if exists DeliveryProduct
go
create table Delivery
(
	Id int primary key identity,
	CustomerId int,
	AddressId int,
	PaymentStatus varchar(64),
	DeliveryStatus varchar(64),
	CreateTime DateTime
)

create table DeliveryProduct
(
	DeliveryId int,
	ProductId int
)

insert into Delivery(CustomerId, AddressId, CreateTime,PaymentStatus, DeliveryStatus) values
(3,1, GETDATE(), 'blik', 'ordered'),
(2,2, GETDATE(), 'blik', 'ordered'),
(1,2, GETDATE(), 'blik', 'ordered'),
(1,1, GETDATE(), 'blik', 'ordered');

select * from Delivery 