using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Common.Constants
{
    public static class ModelConstraintConstants
    {
        public static class Common
        {
            public const int PhoneNumberMaxLength = 17;
            public const int PhoneNumberMinLength = 13;
            public const int EmailMaxLength = 100;
            public const int EmailMinLength = 10;
            public const int UicMaxLength = 12;
            public const int UicMinLength = 12;
            public const int ResponsiblePersonNameMaxLength = 70;
            public const int ResponsiblePersonNameMinLength = 8;
            public const int DocumentNumberMaxLength = 50;
        }
        public static class ShopService
        {
            public const int RepairServiceNameMaxLength = 60;
            public const int RepairServiceNameMinLength = 5;
            public const int RepairServiceDescriptionMaxLength = 400;
            public const int RepairServiceDescriptionMinLength = 5;
            public const string ShopServicePriceMaxValue = "10000";
            public const string ShopServicePriceMinValue = "0.1";
        }

        public static class SparePart
        {
            public const int SparePartNameMaxLength = 50;
            public const int SparePartNameMinLength = 5;
            public const int SparePartManufacturerNameMaxLength = 50;
            public const int SparePartManufacturerNameMinLength = 5;
            public const int SparePartOriginalMpnMaxLength = 30;
            public const int SparePartOriginalMpnMinLength = 5;
            public const int SparePartDescriptionMaxLength = 150;
            public const int SparePartDescriptionMinLength = 5;
            public const int SparePartImageUrlMaxLength = 250;
            public const int SparePartImageUrlMinLength = 20;
            public const string SparePartPriceMaxValue = "10000";
            public const string SparePartPriceMinValue = "0.1";

        }

        public static class Supplier
        {
            public const int SupplierNameMaxLength = 50;
            public const int SupplierNameMinLength = 5;
            public const int SupplierCompanyNameMaxLength = 50;
            public const int SupplierCompanyNameMinLength = 5;

        }

        public static class Address
        {
            public const int TownNameMaxLength = 50;
            public const int TownNameMinLength = 5;
            public const int AddressTextMaxLength = 150;
            public const int AddressTextMinLength = 5;
            public const int ZipCodeMaxLength = 6;
            public const int ZipCodeMinLength = 3;
        }

        public static class Vehicle
        {
            public const int VehicleMakeMaxLength = 30;
            public const int VehicleMakeMinLength = 3;
            public const int VehicleModelMaxLength = 70;
            public const int VehicleModelMinLength = 1;
            public const int LicensePlateMaxLength = 8;
            public const int LicensePlateMinLength = 7;
            public const int VinNumberLength = 17;
            public const int EngineMaxPower = 1914;
            public const int EngineMinPower = 1;
        }

        public static class Customer
        {
            public const int CustomerNameMaxLength = 40;
            public const int CustomerNameMinLength = 6;
        }

        public static class Employee
        {
            public const int EmployeeNameMaxLength = 70;
            public const int EmployeeNameMinLength = 8;
        }

        public class Order
        {
            public const int OrderNoteMaxLength = 200;
        }

        public static class VehicleComponent
        {
            public const int VehicleComponentNameMaxLength = 50;
            public const int VehicleComponentNameMinLength = 4;
        }
        public static class EngineType
        {
            public const int EngineTypeNameMaxLength = 10;
            public const int EngineTypeNameMinLength = 5;
        }
        public static class ApplicationUser
        {
            public const int ApplicationUserFirstNameMaxLength = 40;
            public const int ApplicationUserFirstNameMinLength = 3;
            public const int ApplicationUserLastNameMaxLength = 40;
            public const int ApplicationUserLastNameMinLength = 3;
            public const int ApplicationUserUserNameMaxLength = 40;
            public const int ApplicationUserUserNameMinLength = 3;
        }

        public static class JobTitle
        {
            public const int JobTitleNameMaxLength = 20;
            public const int JobTitleNameMinLength = 5;
        }
    }
}
