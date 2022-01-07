using Hernandes.Customer.Response.Contracts;
using Hernandes.Customer.Response.Entities;

namespace Hernandes.Customer.Response
{
    public class ResponseOk<T> : IResponse
    {
        private readonly T _responseObj;
        private readonly int _responseSize;


        public ResponseOk(T responseObj, int responseSize = 0) =>
            (_responseObj, _responseSize) =
            (responseObj, responseSize);

        public int Count() => _responseSize;

        public Error Error() => null;

        public bool HasError() => false;

        public object ResponseObj() => _responseObj;
    }
}