using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Exceptions
{
    
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new RepairShopException() :
                    new RepairShopException(errorMessage);

                throw exception;
            }
        }
    }
}
