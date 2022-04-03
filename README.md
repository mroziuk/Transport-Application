# Transport Application
ASP.NET app for delivery orders with user authentication, authorization, api for Shop Application
## MVC controllers
### Delivery
* Creating delivery by users and admins
* Geting deliveries, all for admins and only yours for logged users
* Delete and Edit by admins
### Product
Browsing products from database, users logged as admin can edit, add, delete products.
### Account
Implemented Login and Register by ```CustomRoleProvider``` and ```CustomRoleProvider```
### DeliveryApiController
connected to Shop Application, ```Post``` method saves data to database.
