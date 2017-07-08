using System;

namespace PadelManager.Core.Exceptions
{
    public class PadelManagerException: ApplicationException
    {
        public PadelManagerException(string message):base(message)
        {
        }

        public PadelManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}