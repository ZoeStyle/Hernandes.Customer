using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class EmailTest
    {
        [TestCategory("Email Test")]
        [TestMethod("Invalid Characters")]
        public void Invalid_characters_test_1()
        {
            var address = "enzothomascardosoenzothomascardosoenzothomascardosoenzothomascardosoenzothomascardosoenzothomascardoso@beminvestir.com.br";

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddEmail(address);

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Invalid Characters")]
        public void Invalid_characters_test_2()
        {
            var address = "enzothomascardoso";

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddEmail(address);

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Empty")]
        public void Empty()
        {

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddEmail(string.Empty);

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Valid")]
        public void Valid()
        {
            var address = "enzothomascardoso@beminvestir.com.br";

            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.AddEmail(address);

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
