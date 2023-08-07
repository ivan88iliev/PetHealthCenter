using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHealthCenter.Common.Constants
{
    public class ModelConstraintConstants
    {
        public class Common
        {
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 13;
            public const int EmailMaxLength = 110;
            public const int EmailMinLength = 10;
            public const int UicMaxLength = 15;
            public const int UicMinLength = 13;
            public const int ResponsiblePersonNameMaxLength = 70;
            public const int ResponsiblePersonNameMinLength = 8;
            public const int DocumentNumberMaxLength = 50;
        }
        public class HealthService
        {
            public const int HealthServiceNameMaxLength = 60;
            public const int HealthServiceNameMinLength = 5;
            public const int HealthServiceDescriptionMaxLength = 400;
            public const int HealthServiceDescriptionMinLength = 5;
            public const string HealthServicePriceMaxValue = "10000";
            public const string HealthServicePriceMinValue = "0.1";
        }

        public class HealthProduct
        {
            public const int HealthProductNameMaxLength = 50;
            public const int HealthProductNameMinLength = 5;
            public const int HealthProductManufacturerNameMaxLength = 50;
            public const int HealthProductManufacturerNameMinLength = 5;
            public const int HealthProductOriginalMpnMaxLength = 30;
            public const int HealthProductOriginalMpnMinLength = 5;
            public const int HealthProductDescriptionMaxLength = 150;
            public const int HealthProductDescriptionMinLength = 5;
            public const int HealthProductImageUrlMaxLength = 250;
            public const string HealthProductPriceMaxValue = "10000";
            public const string HealthProductPriceMinValue = "0.1";

        }

        public class Supplier
        {
            public const int SupplierNameMaxLength = 50;
            public const int SupplierNameMinLength = 5;
            public const int SupplierCompanyNameMaxLength = 50;
            public const int SupplierCompanyNameMinLength = 5;

        }

        public class Address
        {
            public const int TownNameMaxLength = 50;
            public const int TownNameMinLength = 5;
            public const int AddressTextMaxLength = 150;
            public const int AddressTextMinLength = 5;
            public const int ZipCodeMaxLength = 6;
            public const int ZipCodeMinLength = 3;
        }

        public class Pet
        {
            public const int PetNameMaxLength = 30;
            public const int PetNameMinLength = 5;
            public const int PetSpeciesMaxLength = 70;
            public const int PetSpeciesMinLength = 1;
            public const int AnimalIdentificationNumberMaxLength = 17;
            public const int AnimalIdentificationNumberMinLength = 13;
            public const int HospitalizedNumber = 17;
            public const int PetMaxWeight = 1000;
            public const int PetMinWeight = 1;
        }

        public class Customer
        {
            public const int CustomerNameMaxLength = 70;
            public const int CustomerNameMinLength = 8;
        }

        public class Employee
        {
            public const int EmployeeNameMaxLength = 70;
            public const int EmployeeNameMinLength = 8;
        }

        public class Order
        {
            public const int OrderNoteMaxLength = 200;
        }

        public class MedicalComponent
        {
            public const int MedicalComponentNameMaxLength = 50;
            public const int MedicalComponentNameMinLength = 4;
        }
        public class Breed
        {
            public const int BreedTypeNameMaxLength = 10;
            public const int BreedTypeNameMinLength = 5;
        }
        public class ApplicationUser
        {
            public const int ApplicationUserFirstNameMaxLength = 20;
            public const int ApplicationUserFirstNameMinLength = 3;
            public const int ApplicationUserLastNameMaxLength = 20;
            public const int ApplicationUserLastNameMinLength = 3;
        }

        public class JobTitle
        {
            public const int JobTitleNameMaxLength = 20;
            public const int JobTitleNameMinLength = 5;
        }
    }
}
