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