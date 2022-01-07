using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.Entities
{
    [TestClass]
    public class CustomerTest
    {
        [TestCategory("Customer Validation")]
        [TestMethod("Customer Person Fis Valid")]
        public void Person_fis_valid()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Person Jur Valid")]
        public void Person_Jur_valid()
        {
            var fakeCustomer = FakeCustomerJur();

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Person Jur null")]
        public void Person_Jur_null()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("personJur", null);

            var fakeCustomer = FakeCustomerJur(dic);

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Person Fis null")]
        public void Person_fis_null()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("personFis", null);

            var fakeCustomer = FakeCustomerFis(dic);

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Address Null")]
        public void Customer_address_null()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("address", null);

            var fakeCustomer = FakeCustomerFis(dic);

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Incorrect Address")]
        public void Customer_incorrect_address()
        {
            var address = new Address(
                street: "Rua Octávio Gobbi",
                city: "Colatina",
                state: "ES",
                country: "BR",
                zipCode: "29702-752",
                number: "123456"
                );

            var dic = new Dictionary<string, object>();
            dic.Add("address", address);

            var fakeCustomer = FakeCustomerFis(dic);

            var validate = fakeCustomer.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Add Email Valid")]
        public void Customer_add_email_valid()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validateEmail = fakeCustomer.AddEmail("nicolastiagoianbernardes_@ltecno.com.br");

            Assert.AreEqual(false, validateEmail.HasError());
            Assert.AreEqual(1, validateEmail.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Add Email Invalid")]
        public void Customer_add_email_invalid()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validateEmail = fakeCustomer.AddEmail("nicolastiagoianbernardes_");

            Assert.AreEqual(true, validateEmail.HasError());
            Assert.AreEqual(1, validateEmail.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Add Phone Valid")]
        public void Customer_add_Phone_Valid()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("19", "2591-8864");

            Assert.AreEqual(false, validatePhone.HasError());
            Assert.AreEqual(1, validatePhone.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Add Phone Invalid")]
        public void Customer_add_Phone_Invalid()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("(19)", "2591 -8864");

            Assert.AreEqual(true, validatePhone.HasError());
            Assert.AreEqual(1, validatePhone.Count());
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Fis Update Valid 01")]
        public void Customer_fis_update_valid_01()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("19", "2591-8864");
            var validatePhone2 = fakeCustomer.AddPhone("19", "2591-8865");

            var listPhone = new List<Phone>();
            listPhone.Add(new Phone("19", "2591-8864"));
            listPhone.Add(new Phone("19", "2591-8865"));
            listPhone.Add(new Phone("19", "2591-8866"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentFis(), FakeAddress(), FakePersonFis(), null, listPhone);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(3, fakeCustomer.Phone.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Fis Update Valid 02")]
        public void Customer_fis_update_valid_02()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("19", "2591-8864");
            var validatePhone2 = fakeCustomer.AddPhone("19", "2591-8865");

            var listPhone = new List<Phone>();
            listPhone.Add(new Phone("19", "2591-8864"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentFis(), FakeAddress(), FakePersonFis(), null, listPhone);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(1, fakeCustomer.Phone.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Fis Update Valid 03")]
        public void Customer_fis_update_valid_03()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddEmail("nicolastiagoianbernardes_@ltecno.com.br");
            var validatePhone2 = fakeCustomer.AddEmail("nicolastiagoianbernardes@ltecno.com.br");

            var listEmail = new List<Email>();
            listEmail.Add(new Email("nicolastiagoianbernardes_@ltecno.com.br"));
            listEmail.Add(new Email("nicolastiagoianbernardes@ltecno.com.br"));
            listEmail.Add(new Email("nicolastiago@ltecno.com.br"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentFis(), FakeAddress(), FakePersonFis(), listEmail, null);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(3, fakeCustomer.EmailList.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Fis Update Valid 04")]
        public void Customer_fis_update_valid_04()
        {
            var fakeCustomer = FakeCustomerFis();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddEmail("nicolastiagoianbernardes_@ltecno.com.br");
            var validatePhone2 = fakeCustomer.AddEmail("nicolastiagoianbernardes@ltecno.com.br");

            var listEmail = new List<Email>();
            listEmail.Add(new Email("nicolastiagoianbernardes_@ltecno.com.br"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentFis(), FakeAddress(), FakePersonFis(), listEmail, null);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(1, fakeCustomer.EmailList.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Jur Update Valid 01")]
        public void Customer_Jur_update_valid_01()
        {
            var fakeCustomer = FakeCustomerJur();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddEmail("nicolastiagoianbernardes_@ltecno.com.br");

            var email = new Email("nicolastiagoianbernardes@ltecno.com.br");

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentJur(), FakeAddress(), FakePersonJur(), email, null);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(1, fakeCustomer.EmailList.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Jur Update Valid 02")]
        public void Customer_jur_update_valid_02()
        {
            var fakeCustomer = FakeCustomerJur();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("19", "2591-8864");
            var validatePhone2 = fakeCustomer.AddPhone("19", "2591-8865");

            var listPhone = new List<Phone>();
            listPhone.Add(new Phone("19", "2591-8865"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentJur(), FakeAddress(), FakePersonJur(), null, listPhone);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(1, fakeCustomer.Phone.Count);
        }

        [TestCategory("Customer Validation")]
        [TestMethod("Customer Jur Update Valid 03")]
        public void Customer_jur_update_valid_03()
        {
            var fakeCustomer = FakeCustomerJur();

            var validate = fakeCustomer.Validate();

            var validatePhone = fakeCustomer.AddPhone("19", "2591-8864");
            var validatePhone2 = fakeCustomer.AddPhone("19", "2591-8865");

            var listPhone = new List<Phone>();
            listPhone.Add(new Phone("19", "2591-8864"));
            listPhone.Add(new Phone("19", "2591-8865"));
            listPhone.Add(new Phone("19", "2591-8866"));

            var validateUpdate = fakeCustomer.UpdateCustomer(FakeDocumentJur(), FakeAddress(), FakePersonJur(), null, listPhone);

            Assert.AreEqual(false, validateUpdate.HasError());
            Assert.AreEqual(1, validateUpdate.Count());
            Assert.AreEqual(3, fakeCustomer.Phone.Count);
        }

        private Domain.Entities.Customer FakeCustomerFis(Dictionary<string, object> args = null) =>
            new Domain.Entities.Customer(
                document: args != null && args.ContainsKey("document") ? (Document)args["document"] : FakeDocumentFis(),
                address: args != null && args.ContainsKey("address") ? (Address)args["address"] : FakeAddress(),
                personFis: args != null && args.ContainsKey("personFis") ? (PersonFis)args["personFis"] : FakePersonFis()
                );

        private Domain.Entities.Customer FakeCustomerJur(Dictionary<string, object> args = null) =>
            new Domain.Entities.Customer(
                document: args != null && args.ContainsKey("document") ? (Document)args["document"] : FakeDocumentJur(),
                address: args != null && args.ContainsKey("address") ? (Address)args["address"] : FakeAddress(),
                personJur: args != null && args.ContainsKey("personJur") ? (PersonJur)args["personJur"] : FakePersonJur()
                );

        private Document FakeDocumentFis() =>
        new Document(
            documentNumber: "155.718.756-82",
            type: DocumentType.Fisica
            );

        private Document FakeDocumentJur() =>
            new Document(
                documentNumber: "79.769.045/0001-85",
                type: DocumentType.Juridica
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

        private PersonJur FakePersonJur() =>
            new PersonJur(
                corporateName: "Andreia e Sebastiana Telecomunicações Ltda",
                fantasyName: "Andreia e Sebastiana Telecomunicações Ltda"
                );

    }
}
