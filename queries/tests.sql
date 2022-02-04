select Street
from Delivery
left join Address
on Delivery.AddressId = Address.Id

select * from Delivery

delete
from Delivery 
where Delivery.Id = 7
