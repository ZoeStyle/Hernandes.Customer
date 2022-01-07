using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Response.Contracts;
using Hernandes.Customer.Response.Entities;

namespace Hernandes.Customer.Response
{
    public class ResponseError<T> : IResponse
    {
        private Error _error;
        private readonly int _errorSize;

        public ResponseError(Error error, int errorSize) => 
            (_error, _errorSize) = (error, errorSize);

        public ResponseError(string errorCode, string description, IReadOnlyCollection<Notification> data, int errorSize)
        {
            _error = new Error(errorCode, description, data);
            _errorSize = errorSize;
        }

        public int Count() => _errorSize;

        public Error Error() => _error;

        public bool HasError() => true;

        public object ResponseObj() => "Object not returned because Response contains error.";
    }
}
