using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.Api.Common
{
    public class ValidationException : Exception
    {

        #region ctor
        public ValidationException()
        {

        }
        public ValidationException(string message) : base(message)
        {

        }
        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
        #endregion

    }
}
