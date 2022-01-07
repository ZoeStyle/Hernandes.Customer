using Hernandes.Customer.Response.Entities;

namespace Hernandes.Customer.Response.Contracts
{
    public interface IResponse
    {
        /// <summary>
        /// Return the desired object
        /// </summary>
        /// <returns></returns>
        object ResponseObj();
        /// <summary>
        /// Displays the number of notifications in case of error, 
        /// or if the object is a list it can inform the size of the list
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Informs if there is any error in the operation
        /// </summary>
        /// <returns></returns>
        bool HasError();
        /// <summary>
        /// Returns the error
        /// </summary>
        /// <returns></returns>
        Error Error();
    }
}
