# PetHealthCenter

Pet Health Center is a mockup application designed to help managing small veterinary facility.

> The application allows to operate with:
```
> * Customers (corporate and regular) with their pets
> * Health services
> * Medical products in a storage
> * Operating cards (document conaining information about a certain procedures or service)
```


> * **TODO:** Create and send via E-mail request for delivery of goods directly to suppliers 


** Roles and authorization
```
> * Admin (Manager)
>   - As admin, you have access to "Admin" area, where you can create, read, update and delete customers, services and medical products. 
>   - You can create profiles of new users (employees) and you can define what role will they have and therefore what they will have access to.
>   - You can generate operating cards

> * Service adviser
>   - As Service adviser, you can create, read, update customers and medical products. 
>   - You can read health services
>   - You can generate and read operating cards
>   - You can create profiles of new users (employees) and you can define what role will they have and therefore what they will have access to.
>   - You can generate operating cards

> * Doctor
>   - As Doctor you can read and change the status of the operating cards ("Pending" or "Completed")
>   - You can read all medical products in the storage
```


** Credentials
```
> * Admin (Manager)
>   - Username: General_Manager
>   - Password: Manager123!

> * Mechanic
>   - Username: Doctor
>   - Password: Doctor123!

> * Service adviser
>   - Username: Service_Adviser
>   - Password: Adviser123!
```


** Seeding
```
> * Data in DB
>   - In all entities are seeded by one or two objects (depending on the quantity required to start a demo)
>   - Seeding classes are located at: PetHealthCenter.Infrastructure.Data.Configuration

> * Roles
>   - For each role there is seeded one instance / user
>   - Seeding method is located at: PetHealthCenter.Extensions.ApplicationBuilderExtensions
```

###### This project is created for educational purposes only. 
