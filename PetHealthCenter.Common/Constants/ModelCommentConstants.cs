namespace PetHealthCenter.Common.Constants
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
            public const string AddViewModelPet = "Model of animal, owned by the customer";
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
            public const string ViewModelPetId = "Pet owned by the customer";
            public const string ViewModelPets = "Collection of animals, owned by the customer";
        }

        public static class SpecieType
        {
            public const string ViewModelMain = "Model, used to view specie types details";
            public const string ViewModelId = "Id of the specie type";
            public const string ViewModelName = "Name of specie type";
        }

        public static class OperatingCard
        {
            public const string AddViewModelMain = "Model, uset to add operating cards";
            public const string AddViewModelId = "Id of the operating card";
            public const string AddViewModelCustomerId = "The id of the customer";
            public const string AddViewModelCustomerName = "The name of the customer";
            public const string AddViewModelPetId = "The id of the animal"; 
            public const string AddViewModelPets = "Collection of animals of the current customer"; 
            public const string AddViewModelApplicationUserId = "The Id of the user (doctor) that must perform the service"; 
            public const string AddViewModelApplicationUsers = "Collection of all users/doctors that are can perform the service";
            public const string AddViewModelPartId = "The id of the part, used to perform the service";
            public const string AddViewModelParts = "Collection of all parts in storage, that can be used to perform the services";
            public const string AddViewModelServiceId = "The id of the service";
            public const string AddViewModelIssueDate = "Date of creation of the document";
            public const string AddViewModelIsActive = "Property that defines if the operating card is active";

            public const string ViewModelMain = "Model, used to view operating card details";
            public const string ViewModelId = "The id of the operating card";
            public const string ViewModelPartName = "The name of the part, used to perform the service";
            public const string ViewModelServiceName = "The name of the service";
            public const string ViewModelCustomerName = "The name of the customer";
            public const string ViewModelPetIdentificationNumber = "The identification number number of the animal";
            public const string ViewModelDoctorName = "The name of the doctor, performing the service";
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
            public const string AddViewModelPriceSell = "Selling price (by the pet health center)";
            public const string AddViewModelProductComponentId = "The Id of the product component, the part is used for";
            public const string AddViewModelProductComponents = "Collection of product components";

            public const string EditViewModelMain = "Model, used to edit a part";
            public const string EditViewModelId = "The id of the part";
            public const string EditViewModelName = "The name of the part";
            public const string EditViewModelImageUrl = "ImageURl of the part";
            public const string EditViewModelStock = "Part's availability";
            public const string EditViewModelManufacturer = "Manufacturer of the part's name";
            public const string EditViewModelOriginalMpn = "Part's MPN by the manufacturer";
            public const string EditViewModelDescription = "Description of the part";
            public const string EditViewModelPriceBuy = "Delivery price (by the supplier)";
            public const string EditViewModelPriceSell = "Selling price (by the pet health center)";
            public const string EditViewModelProductComponentId = "The Id of the product component, the part is used for";
            public const string EditViewModelProductComponents = "Collection of product components";

            public const string DetailsModelMain = "Model to view part details";
            public const string DetailsModelIdProductComponent = "The animal compnent of the part";

            public const string ServiceModelMain = "Additional model to PartDetailsModel";
            public const string ServiceModelId = "The id of the part";
            public const string ServiceModelName = "The name of the part";
            public const string ServiceModelImageUrl = "ImageURl of the part";
            public const string ServiceModelStock = "Part's availability";
            public const string ServiceModelManufacturer = "Manufacturer's name of the part";
            public const string ServiceModelOriginalMpn = "Part's MPN by the car manufacturer";
            public const string ServiceModelDescription = "Description of the part";
            public const string ServiceModelPriceBuy = "Delivery price (by the supplier)";
            public const string ServiceModelPriceSell = "Selling price (by the pet health center)";
            public const string ServiceModelProductComponent = "Product component where the part must be used";

            public const string ProductComponentModelMain = "Model, used to view the product component of a part details";
            public const string ProductComponentModelId = "The id of the product component";
            public const string ProductComponentModelName = "The name of the product component";

            public const string ViewModelMain = "Model, used to view part details";
            public const string ViewModelId = "The id of the part";
            public const string ViewModelName = "The name of the part";
            public const string ViewModelImageUrl = "ImageURl of the part";
            public const string ViewModelStock = "Part's availability";
            public const string ViewModelManufacturer = "Manufacturer's name of the part";
            public const string ViewModelOriginalMpn = "Part's MPN by the car manufacturer";
            public const string ViewModelDescription = "Description of the part";
            public const string ViewModelPriceSell = "Selling price (by the pet health center)";
            public const string ViewModelPriceBuy = "Delivery price (by the supplier)";
            public const string ViewModelProductComponentId = "The id of the product component";
            public const string ViewModelProductComponent = "Name of product component";
            public const string ViewModelProductComponents = "Collection of all product components";
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

        public static class Pet
        {
            public const string AddViewModelMain = "Model, used to add a animal";
            public const string AddViewModelId = "The Id of the animal";
            public const string AddViewModelMake = "Pet make name";
            public const string AddViewModelModel = "Pet model name";
            public const string AddViewModelIdentificationNUmber = "Identification number of the animal";
            public const string AddViewModelFIrstRegistration = "Date of the first registration of the animal";
            public const string AddViewModelSpecieTypeId = "The Id of the specie type";
            public const string AddViewModelPower = "Specie power in Hp";
            public const string AddViewModelVinNumber = "VIN number of the animal";
            public const string AddViewModelSpecieTypes = "Collection of all specie types";
        }
    }
}
