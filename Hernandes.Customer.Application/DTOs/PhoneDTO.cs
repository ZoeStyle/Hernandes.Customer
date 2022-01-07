namespace Hernandes.Customer.Application.DTOs
{
    public class PhoneDTO
    {
        public PhoneDTO()
        { }

        public PhoneDTO(string ddd, string number)
        {
            Ddd = ddd;
            Number = number;
        }

        /// <summary>
        /// DDD
        /// </summary>
        /// <example>61</example>
        public string Ddd { get; set; }

        /// <summary>
        /// Número do telefone
        /// </summary>
        /// <example>98225-6373</example>
        public string Number { get; set; }
    }
}
