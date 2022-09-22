using System;
using System.Runtime.Serialization;
namespace Hotel
{
    [Serializable]
    internal class ItemNotFoundInMinibarException : Exception
    {
        public ItemNotFoundInMinibarException()
        {
        }

        public ItemNotFoundInMinibarException(string message) : base(message)
        {
        }

        public ItemNotFoundInMinibarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundInMinibarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
