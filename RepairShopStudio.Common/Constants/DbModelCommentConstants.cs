namespace RepairShopStudio.Common.Constants
{
    public static class DbModelCommentConstants
    {
        public static class ApplicationUser
        {
            public const string ApplicationUserMain = "Additional user properties";
            public const string ApplicationUserFirstName = "User's first name";
            public const string ApplicationUserLastName = "User's last name";
            public const string ApplicationUserIsActive = "Property that defines if the user is active";
        }

        public static class Address
        {
            public const string AddressMain = "Addres properties";
            public const string AddressAddressText = "Adrres text - street, number, etc.";
            public const string AddressTownName = "Town name";
            public const string AddressZipCode = "ZIP code of the town";
        }

        public static class Customer
        {
            public const string CustomerMain = "Customer information";
            public const string CustomerId = "The Id of the customer";
            public const string CustomerName = "Name of the customer";
            public const string CustomerPhoneNumber = "Phone number of the cusotmer";
            public const string CustomerEmail = "E-mail of the customer";
            public const string CustomerIsCorporate = "Defines if the customer is corporate";
            public const string CustomerUic = "The Unit Identification Code of the customer's company";
            public const string CustomerAddressId = "The address of the customer's office";
            public const string CustomerAddress = "The addres of the customer";
            public const string CustomerResponsiblePerson = "Name of the responsible person of the customer's company";
            public const string CustomerVehicles = "Collection of vehicles, owned by the customer";
        }

        public static class EngineType
        {

            public const string EngyneTypeMain = "Types of the vehicles engine";
            public const string EngyneTypeId = "The Id of the engine type";
            public const string EngyneTypeName = "Name of engine type";
        }

        public static class JobTitle
        {
            public const string JobTitleMain = "Job titles of the employee";
            public const string JobTitleId = "The Id of the job title";
            public const string JobTitleName = "Name of job title";
        }

        public static class OperatingCard
        {
            public const string OperatingCardMain = "Operating card for the current service";
            public const string OperatingCardId = "The Id of the operating card";
            public const string OperatingCardDate = "Date of the creation of the document";
            public const string OperatingCardDocumentNumber = "The number of current document";
            public const string OperatingCardPartId = "The Id of part used in repair";
            public const string OperatingCardPart = "The part used in repair";
            public const string OperatingCardServiceId = "The Id of the service, needed to be performed for the repair";
            public const string OperatingCardService = "The service, needed to be performed for the repair";
            public const string OperatingCardCustomerId = "The id of the customer, owning the repaired vehicle";
            public const string OperatingCardCustomer = "The customer, owning the repaired vehicle";
            public const string OperatingCardApplicationUserId = "The Id of the user (mechanic) performing the repair";
            public const string OperatingCardApplicationUser = "The user (mechanic) performing the repair";
            public const string OperatingCardIsActive = "Property that defines if the operating card is active";
            public const string OperatingCardVehicleId = "The id of repaired vehicle";
        }

        public static class Order
        {
            public const string OrderMain = "Order of parts properties";
            public const string OrderId = "The Id of the order";
            public const string OrderNumber = "The number of the document/order";
            public const string OrderIssueDate = "Date of the creation of the order";
            public const string OrderParts = "Collection of ordered parts";
            public const string OrderNote = "A note to the current order";
            public const string OrderSupplierId = "The Id of the supplier who delivers the goods";
            public const string OrderSupplier = "The supplier who delivers the goods";
            public const string OrderIsActive = "Property that defines if the order is active";
        }

        public static class Part
        {
            public const string PartMain = "Part, stored in the shop's warehouse";
            public const string PartId = "The Id of the part";
            public const string PartName = "The name of the part";
            public const string PartImageUrl = "The image URL of the part";
            public const string PartStock = "Part's availability";
            public const string PartManufacturer = "Manufacturer's name of the part";
            public const string PartOriginalMpn = "Part's MPN by the car manufacturer";
            public const string PartDescription = "Description of the part";
            public const string PartPriceBuy = "Delivery price (by the supplier)";
            public const string PartPriceSell = "Selling price (by the repair shop)";
            public const string PartVehicleComponentId = "The Id of affected part of the vehicle, where the part may be used";
            public const string PartVehicleComponent = "Affected part of the vehicle, where the part may be used";
            public const string PartSupplierSpareParts = "Collection of suppliers, selling the part";
            public const string PartIsActive = "Property that defines if the part is active";
        }

        public static class ShopService
        {
            public const string ShopServiceMain = "Services, offered by repair shop";
            public const string ShopServiceId = "The Id of the shop service";
            public const string ShopServiceName = "Name of the service";
            public const string ShopServiceDescription = "Description of the service";
            public const string ShopServicePrice = "Price of the service";
            public const string ShopServiceVehicleComponentId = "The Id of the affected part of the vehicle";
            public const string ShopServiceVehicleComponent = "Affected part of the vehicle";
            public const string ShopServiceParts = "Collection of spare parts needed for the service";
            public const string ShopServiceIsActive = "Property that defines if the service is active";
        }

        public static class Supplier
        {
            public const string SupplierMain = "Supplier, who delivers parts to the repair shop";
            public const string SupplierId = "The Id of the supplier";
            public const string SupplierName = "Name of the supplier";
            public const string SupplierCompanyName = "Name of the supplier's company";
            public const string SupplierUic = "Unit Identification Code of the supplier's company";
            public const string SupplierPhoneNumber = "Phone number of the supplier's office";
            public const string SupplierEmail = "E-mail of the supplier";
            public const string SupplierSupplierSpareParts = "Collection of parts, selled by the supplier";
            public const string SupplierAddressId = "The Id of address of the supplier's office";
            public const string SupplierAddress = "The address of the supplier's office";
        }

        public static class Vehicle
        {
            public const string VehicleMain = "Vehicle, owned by customer";
            public const string VehicleId = "The Id of the vehicle";
            public const string VehicleMake = "Vehicle make name";
            public const string VehicleModel = "Vehicle model name";
            public const string VehicleLicensePlate = "License plate number of the vehicle";
            public const string VehicleFirstRegistration = "Date of the first registration of the vehicle";
            public const string VehicleEngineTypeId = "The Id of the engine type of the vehicle";
            public const string VehicleEngineType = "Engine type of the vehicle";
            public const string VehiclePower = "Enginge power in Hp";
            public const string VehicleVinNumber = "VIN number of the vehicle";
            public const string VehicleCustomerId = "The Id of the customer/owner of the vehicle";
            public const string VehicleCustomer = "Customer/owner of the vehicle";
        }

        public static class VehicleComponent
        {
            public const string VehicleComponentMain = "The components/parts of the vehicle, which can be affected by the services";
            public const string VehicleComponentId = "The Id of the vehicle component";
            public const string VehicleComponentName = "Name of vehicle component";
        }

        public static class OperatingCardParts
        {
            public const string OperatingCardPartsMain = "Mapping entity between OperatingCards and Parts entities";
        }

        public static class OperatingCardShopService
        {
            public const string OperatingCardShopServiceMain = "Mapping entity between OperatingCards and ShopServices entities";
        }

        public static class SupplierSparePart
        {
            public const string SupplierSparePartMain = "Mapping entity between suppliers and parts";
        }
    }
}
