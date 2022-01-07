namespace Hernandes.Customer.Application.DTOs
{
    public class EmailDTO
    {
        public EmailDTO()
        { }
        public EmailDTO(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Endereço de email
        /// </summary>
        /// <example>marcosviniciusthiagoramos@truckeixo.com.br</example>
        public string Address { get; set; }
    }
}
