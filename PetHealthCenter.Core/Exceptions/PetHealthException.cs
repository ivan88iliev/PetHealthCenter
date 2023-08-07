using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Exceptions
{
   
    public class PetHealthException : ApplicationException
    {
        public PetHealthException()
        {

        }

        public PetHealthException(string errorMessage)
            :base(errorMessage)
        {
        }
    }
}
