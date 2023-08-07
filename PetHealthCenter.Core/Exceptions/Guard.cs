using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Exceptions
{
    
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new PetHealthException() :
                    new PetHealthException(errorMessage);

                throw exception;
            }
        }
    }
}
