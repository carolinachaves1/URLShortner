using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Exceptions
{
    public class DataAccessException : ApplicationException
    {
        public DataAccessException(string message) : base(message)
        {

        }
    }
}
