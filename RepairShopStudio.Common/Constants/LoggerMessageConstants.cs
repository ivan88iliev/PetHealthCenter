using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Common.Constants
{
    public static class LoggerMessageConstants
    {
        public const string UnauthorizedAction = "Action attempted by an unauthorized user";
        public const string InvalidDataEntered = "Invalid data entered";
        public const string ExistingObject = "Attempt to create an already existing object";
        public const string NullAddres = "Address cannot be null";
        public const string NullCustomer = "Customer cannot be null";
        public const string NullUser = "User cannot be null";
        public const string NullPart = "Part cannot be null";
        public const string NullShopService = "Part cannot be null";
        public const string NullVehicle = "Vehicle cannot be null";
        public const string NullOperatingCard = "Operating card cannot be null";
        public const string GetDataUnsuccessfull = "Something went wrong while executing method to collect data from data-base.";
    }
}
