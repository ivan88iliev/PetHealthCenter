namespace RepairShopStudio.Common.Constants
{
    public static class ModelCommentConstants
    {
        public static class Address
        {
            public const string AddViewModelMain = "Model, used to add addresses";
            public const string AddViewModelAddressText = "Adrres text - street, number, etc.";
            public const string AddViewModelTownName = "The name of the town";
            public const string AddViewModelZipCode = "ZIP code of the town";
        }

        public static class Custommer
        {
            public const string AddViewModelMain = "Model, used to add new customers";
            public const string AddViewModelName = "Name of the customer";
            public const string AddViewModelPhoneNumber = "Phone number of the cusotmer";
            public const string AddViewModelEmail = "Email of the customer";
            public const string AddViewModelIsCorporate = "Defines if the customer is corporate or individual";
            public const string AddViewModelUic = "The Unit Identification Code of the customer's company";
            public const string AddViewModelResponsiblePerson = "Name of the responsible person of the customer's company";
            public const string AddViewModelVehicle = "Model of vehicle, owned by the customer";
            public const string AddViewModelAddress = "Model of address, owned by the customer";

            public const string ViewModelMain = "Model, used to view customer details";
            public const string ViewModelId = "The Id of the customer";
            public const string ViewModelName = "Name of the customer";
            public const string ViewModelPhoneNumber = "Phone number of the cusotmer";
            public const string ViewModelEmail = "Email of the customer";
            public const string ViewModelIsCorporate = "Defines if the customer is corporate or individual";
            public const string ViewModelUic = "The Unit Identification Code of the customer's company";
            public const string ViewModelAddress = "The address of the customer's office";
            public const string ViewModelResponsiblePerson = "Name of the responsible person of the customer's company";
            public const string ViewModelVehicleId = "Vehicle owned by the customer";
            public const string ViewModelVehicles = "Collection of vehicles, owned by the customer";
        }

        public static class EngineType
        {
            public const string ViewModelMain = "Model, used to view engine types details";
            public const string ViewModelId = "Id of the engine type";
            public const string ViewModelName = "Name of engine type";
        }

        public static class OperatingCard
        {
            public const string AddViewModelMain = "Model, uset to add operating cards";
            public const string AddViewModelId = "Id of the operating card";
            public const string AddViewModelCustomerId = "The id of the customer";
            public const string AddViewModelCustomerName = "The name of the customer";
            public const string AddViewModelVehicleId = "The id of the vehicle"; 
            public const string AddViewModelVehicles = "Collection of vehicles of the current customer"; 
            public const string AddViewModelApplicationUserId = "The Id of the user (mechanic) that must perform the service"; 
            public const string AddViewModelApplicationUsers = "Collection of all users/mechanics that are can perform the service";
            public const string AddViewModelPartId = "The id of the part, used to perform the service";
            public const string AddViewModelParts = "Collection of all parts in storage, that can be used to perform the services";
            public const string AddViewModelServiceId = "The id of the service";
            public const string AddViewModelShopServices = "Collection of all survices, that can be performed";
            public const string AddViewModelIssueDate = "Date of creation of the document";
            public const string AddViewModelIsActive = "Property that defines if the operating card is active";

            public const string ViewModelMain = "Model, used to view operating card details";
            public const string ViewModelId = "The id of the operating card";
            public const string ViewModelPartName = "The name of the part, used to perform the service";
            public const string ViewModelServiceName = "The name of the service";
            public const string ViewModelCustomerName = "The name of the customer";
            public const string ViewModelVehicleLicensePlate = "The license plate number of the vehicle";
            public const string ViewModelMechanicName = "The name of the mechanic, performing the service";
            public const string ViewModelDocumentNumber = "The number of the operating card";
            public const string ViewModelIssueDate = "The date of creation of the operating card";
            public const string ViewModelIsActive = "Property that defines if the operating card is active";
        }

        public static class Part
        {
            public const string AddViewModelMain = "Model, used to add new parts to the storage";
            public const string AddViewModelId = "The id of the part";
            public const string AddViewModelName = "The name of the part";
            public const string AddViewModelImageUrl = "ImageURl of the part";
            public const string AddViewModelStock = "Part's availability";
            public const string AddViewModelManufacturer = "Manufacturer of the part's name";
            public const string AddViewModelOriginalMpn = "Part's MPN by the manufacturer";
            public const string AddViewModelDescription = "Description of the part";
            public const string AddViewModelPriceBuy = "Delivery price (by the supplier)";
            public const string AddViewModelPriceSell = "Selling price (by the repair shop)";
            public const string AddViewModelVehicleComponentId = "The Id of the vehicle component, the part is used for";
            public const string AddViewModelVehicleComponents = "Collection of vehicle components";

            public const string EditViewModelMain = "Model, used to edit a part";
            public const string EditViewModelId = "The id of the part";
            public const string EditViewModelName = "The name of the part";
            public const string EditViewModelImageUrl = "ImageURl of the part";
            public const string EditViewModelStock = "Part's availability";
            public const string EditViewModelManufacturer = "Manufacturer of the part's name";
            public const string EditViewModelOriginalMpn = "Part's MPN by the manufacturer";
            public const string EditViewModelDescription = "Description of the part";
            public const string EditViewModelPriceBuy = "Delivery price (by the supplier)";
            public const string EditViewModelPriceSell = "Selling price (by the repair shop)";
            public const string EditViewModelVehicleComponentId = "The Id of the vehicle component, the part is used for";
            public const string EditViewModelVehicleComponents = "Collection of vehicle components";

            public const string DetailsModelMain = "Model to view part details";
            public const string DetailsModelIdVehicleComponent = "The vehicle compnent of the part";

            public const string ServiceModelMain = "Additional model to PartDetailsModel";
            public const string ServiceModelId = "The id of the part";
            public const string ServiceModelName = "The name of the part";
            public const string ServiceModelImageUrl = "ImageURl of the part";
            public const string ServiceModelStock = "Part's availability";
            public const string ServiceModelManufacturer = "Manufacturer's name of the part";
            public const string ServiceModelOriginalMpn = "Part's MPN by the car manufacturer";
            public const string ServiceModelDescription = "Description of the part";
            public const string ServiceModelPriceBuy = "Delivery price (by the supplier)";
            public const string ServiceModelPriceSell = "Selling price (by the repair shop)";
            public const string ServiceModelVehicleComponent = "Vehicle component where the part must be used";

            public const string VehicleCopmonentModelMain = "Model, used to view the vehicle component of a part details";
            public const string VehicleCopmonentModelId = "The id of the vehicle component";
            public const string VehicleCopmonentModelName = "The name of the vehicle component";

            public const string ViewModelMain = "Model, used to view part details";
            public const string ViewModelId = "The id of the part";
            public const string ViewModelName = "The name of the part";
            public const string ViewModelImageUrl = "ImageURl of the part";
            public const string ViewModelStock = "Part's availability";
            public const string ViewModelManufacturer = "Manufacturer's name of the part";
            public const string ViewModelOriginalMpn = "Part's MPN by the car manufacturer";
            public const string ViewModelDescription = "Description of the part";
            public const string ViewModelPriceSell = "Selling price (by the repair shop)";
            public const string ViewModelPriceBuy = "Delivery price (by the supplier)";
            public const string ViewModelVehicleComponentId = "The id of the vehicle component";
            public const string ViewModelVehicleComponent = "Name of vehicle component";
            public const string ViewModelVehicleComponents = "Collection of all vehicle components";
        }

        public static class ShopService
        {
            public const string AddViewModelMain = "Model, used to add new shop service";
            public const string AddViewModelName = "Name of the service";
            public const string AddViewModelDescription = "Description of the service";
            public const string AddViewModelPrice = "Price of the service";
            public const string AddViewModelVehicleComponentId = "The id of the affected vehicle component";
            public const string AddViewModelVehicleComponents = "Collection of all vehicle components";

            public const string DetailsViewModelMain = "Model, used to edit the shop service";
            public const string DetailsViewModelId = "The id of the service";
            public const string DetailsViewModelName = "Name of the service";
            public const string DetailsViewModelDescription = "Description of the service";
            public const string DetailsViewModelPrice = "Price of the service";
            public const string DetailsViewModelVehicleComponent = "Affected part of the vehicle";

            public const string VehicleComponentViewModelMain = "Model,used to to view service's vehicle model details";
            public const string VehicleComponentViewModelId = "The id of the vehicle component";
            public const string VehicleComponentViewModelName = "The name of the vehicle component";

            public const string ServiceViewModelmain = "Model, used to view shop service details";
            public const string ServiceViewModelId = "The Id of the shop service";
            public const string ServiceViewModelName = "Name of the service";
            public const string ServiceViewModelDescription = "Description of the service";
            public const string ServiceViewModelPrice = "Price of the service";
            public const string ServiceViewModelVehicleComponentId = "The Id of the vehicle component affected";
            public const string ServiceViewModelVehicleComponent = "Name of vehicle component";
            public const string ServiceViewModelVehicleComponents = "Collection of all vehicle components";
        }

        public static class Statistics
        {
            public const string ServiceViewModelMain = "Model, used to generate statistics";
            public const string ServiceViewModelTotalParts = "Propery for the count of all of the parts into the storage";
            public const string ServiceViewModelTotalServices = "Propery for the count of all of the services";
            public const string ServiceViewModelTotalCustomers = "Propery for the count of all of the customers";
            public const string ServiceViewModelTotalOpeartingCards = "Propery for the count of all of the operating cards";
        }

        public static class User
        {
            public const string EditViewModelMain = "Model, used to edit the user";
            public const string EditViewModelUser = "Propery that defines the current user";
            public const string EditViewModelRoles = "Collection of all roles, that can be assigned to user";

            public const string LoginViewModelMain = "Model, used for user's login";
            public const string LoginViewModelUserName = "User's username";
            public const string LoginViewModelPassword = "User's password";
            public const string LoginViewModelReturnUrl = "Return URL after Login";

            public const string RegisterViewModelMain = "Model, used to register a user";
            public const string RegisterViewModelUserName = "User's username";
            public const string RegisterViewModelFirstName = "User's first name";
            public const string RegisterViewModelLastName = "User's last name";
            public const string RegisterViewModelEmail = "User's e-mail";
            public const string RegisterViewModelPassword = "User's password";
            public const string RegisterViewModelConfirmPassword = "User's pasword for confirmation";
        }

        public static class Vehicle
        {
            public const string AddViewModelMain = "Model, used to add a vehicle";
            public const string AddViewModelId = "The Id of the vehicle";
            public const string AddViewModelMake = "Vehicle make name";
            public const string AddViewModelModel = "Vehicle model name";
            public const string AddViewModelLicensePLate = "License plate of the vehicle";
            public const string AddViewModelFIrstRegistration = "Date of the first registration of the vehicle";
            public const string AddViewModelEngineTypeId = "The Id of the engine type";
            public const string AddViewModelPower = "Enginge power in Hp";
            public const string AddViewModelVinNumber = "VIN number of the vehicle";
            public const string AddViewModelEngineTypes = "Collection of all engine types";
        }
    }
}
