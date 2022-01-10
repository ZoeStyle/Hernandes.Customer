using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class PhoneTest
    {
        [TestCategory("Phone Test")]
        [TestMethod("Invalid validation")]
        public void Invalid()
        {
            var ddd = "795";
            var number = "99817-73042";

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddPhone(ddd,number);

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(2, validate.Count());
        }

        [TestCategory("Phone Test")]
        [TestMethod("Valid validation")]
        public void Valid()
        {
            var ddd = "79";
            var number = "99817-7304";

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddPhone(ddd, number);

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private Domain.Entities.Customer FakeCustomerFis() =>
            new Domain.Entities.Customer(
                document: FakeDocumentFis(),
                address: FakeAddress(),
                personFis: FakePersonFis()
                );

        private Document FakeDocumentFis() =>
        new Document(
            documentNumber: "155.718.756-82",
            type: DocumentType.Fisica
            );

        private Address FakeAddress() =>
            new Address(
                street: "Rua Octávio Gobbi",
                city: "Colatina",
                state: "ES",
                country: "BR",
                zipCode: "29702-752",
                number: "870"
                );

        private PersonFis FakePersonFis() =>
            new PersonFis(
                name: "Henrique Fábio Rocha",
                gender: Gender.Masculino,
                birthDay: null,
                rg: "33.310.653-2"
                );
    }
}
