select Street
from Delivery
left join Address
on Delivery.AddressId = Address.Id
