namespace PetHealthCenter.Common.Constants
{
    public static class ExceptionMessagesConstants
    {
        public const string InvalidAddressException = "Something went wrong while creating the address!";
        public const string InvalidCustomerException = "Something went wrong while creating the customer!";
        public const string InvalidPetException = "Something went wrong while creating the animal!";
        public const string InvalidGetAllException = "Something went wrong while getting all customers from data-base!";
        public const string InvalidGetSpecieTypeException = "Something went wrong while getting specie types from data-base!";
        public const string InvalidOperatingCardException = "Something went wrong while creating the operating card!";
        public const string InvalidGetAllFinishedOperatingCardsException = "Something went wrong while getting all completed operating cards from data-base!";
        public const string InvalidCustomerIdException = "Customer with this Id does not exists in data-base!";
        public const string InvalidGetCustomersException = "Something went wrong while getting all customers from data-base!";
        public const string InvalidGetCustomerPetsException = "Something went wrong while getting all customer animals from data-base!";
        public const string InvalidGetDoctorsException = "Something went wrong while getting all doctors from data-base!";
        public const string InvalidGetPartsException = "Something went wrong while getting all parts from data-base!";
        public const string InvalidCardIdExceptionMessage = "The Id of the operating card is invalid!";
        public const string InvalidUserIdExceptionMessage = "The Id of the user is invalid!";
        public const string PartDoesNotExistExceptionMessage = "No such part exists in data-base!";
        public const string InvalidPartException = "Something went wrong while creating the part!";
        public const string InvalidPartIdException = "Part with this Id does not exists in data-base!";
        public const string InvalidGetProductComponentsException = "Something went wrong while getting all product components from data-base!";
        public const string InvalidGetPartProductComponentException = "Something went wrong while getting part's product components from data-base!";
        public const string InvalidGetPartDeatalsException = "Part with this Id does not exists in data base or it's property IsActive == false";
        public const string InvalidGetManufacturersException = "Something went wrong while getting all parts manufacturer from data-base!";
        public const string InvalidGetAllOperatingCardsException = "Something went wrong while getting all operating cards from data-base!";
        public const string UnauthorizedActionException = "User is not authorized to perform this action!";

    }
}
