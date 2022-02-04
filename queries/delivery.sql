drop table if exists Delivery;
go
drop table if exists DeliveryProduct
go
create table Delivery
(
	Id int primary key identity,
	CustomerId int not null,
	AddressFromId int not null,
	AddressToId int not null,
	PaymentStatus varchar(64),
	DeliveryStatus varchar(64),
	CreateTime DateTime
)

create table DeliveryProduct
(
	DeliveryId int,
	ProductId int
)

insert into Delivery(CustomerId, AddressFromId,AddressToId, CreateTime,PaymentStatus, DeliveryStatus) values
(3,1,2, GETDATE(), 'blik', 'ordered'),
(2,2,3, GETDATE(), 'blik', 'ordered'),
(1,2,1, GETDATE(), 'blik', 'ordered'),
(1,1,2, GETDATE(), 'blik', 'ordered');

select * from Delivery 
select * from Customer