using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hernandes.Customer.Infra.Context
{
    public class StoreDataContextSeed
    {
        public static void SeedData(IMongoCollection<Domain.Entities.Customer> customerCollection)
        {
            bool existCustomer = customerCollection.Find(c => true).Any();

            if (!existCustomer)
            {
                customerCollection.InsertManyAsync(GetMyCustomers());
            }
        }

        private static IEnumerable<Domain.Entities.Customer> GetMyCustomers() =>
            new List<Domain.Entities.Customer>()
            {
                new Domain.Entities.Customer
                (
                    new Domain.ValueObjects.Document
                    (
                        "809.660.260-80",
                        Domain.Enums.DocumentType.Fisica
                    ),
                    new Domain.ValueObjects.Address
                    (
                        "Rua Oceano Pacífico",
                        "Natal",
                        "RN",
                        "BR",
                        "59123-420",
                        "626"
                    ),
                    new Domain.ValueObjects.PersonFis
                    (
                        "Bryan Anderson Leandro da Conceição",
                        Domain.Enums.Gender.Masculino,
                        new DateTime(1992,01,01),
                        "23.125.102-6"
                    )
                ),
                new Domain.Entities.Customer
                (
                    new Domain.ValueObjects.Document
                    (
                        "732.546.012-03",
                        Domain.Enums.DocumentType.Fisica
                    ),
                    new Domain.ValueObjects.Address
                    (
                        "Rua C-83",
                        "Maceió",
                        "AL",
                        "BR",
                        "57085-033",
                        "211"
                    ),
                    new Domain.ValueObjects.PersonFis
                    (
                        "Márcio Leandro Ruan Ferreira",
                        Domain.Enums.Gender.Masculino,
                        new DateTime(1992,01,05),
                        "32.754.590-2"
                    )
                ),
                new Domain.Entities.Customer
                (
                    new Domain.ValueObjects.Document
                    (
                        "47.312.894/0001-19",
                        Domain.Enums.DocumentType.Juridica
                    ),
                    new Domain.ValueObjects.Address
                    (
                        "Rua Wilson Roberto de Jesus 231",
                        "Ribeirão Preto",
                        "SP",
                        "BR",
                        "57085-033",
                        "917"
                    ),
                    new Domain.ValueObjects.PersonJur
                    (
                        "Daniela e Isabela Pizzaria Delivery ME",
                        "Daniela e Isabela Pizzaria Delivery ME"
                    )
                ),
                new Domain.Entities.Customer
                (
                    new Domain.ValueObjects.Document
                    (
                        "47.312.894/0001-19",
                        Domain.Enums.DocumentType.Juridica
                    ),
                    new Domain.ValueObjects.Address
                    (
                        "Rua Victor Atolino",
                        "Campo Limpo Paulista",
                        "SP",
                        "BR",
                        "13234-400",
                        "965"
                    ),
                    new Domain.ValueObjects.PersonJur
                    (
                        "Stefany e Benedito Alimentos ME",
                        "Stefany e Benedito Alimentos ME"
                    )
                )
            };
    }
}
