using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Exceptions
{
   
    public class RepairShopException : ApplicationException
    {
        public RepairShopException()
        {

        }

        public RepairShopException(string errorMessage)
            :base(errorMessage)
        {
        }
    }
}
