using Hernandes.Customer.Application.Commands;
using Hernandes.Customer.Application.DTOs;
using Hernandes.Customer.Response.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Application.Test.Commands
{
    [TestClass]
    public class CreateCustomerPersonJurCommandTest
    {
        [TestMethod("CNPJ Null")]
        public void Cnpj_null()
        {
            var dic = new Dictionary<string, object>();
            dic["cnpj"] = null;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(2, validation.Count());
        }

        [TestMethod("Cnpj Empty")]
        public void Cnpj_empty()
        {
            var dic = new Dictionary<string, object>();
            dic["cnpj"] = string.Empty;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(2, validation.Count());
        }

        [TestMethod("Company Name Null")]
        public void CorporateName_null()
        {
            var dic = new Dictionary<string, object>();
            dic["corporateName"] = null;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Company Name Empty")]
        public void CorporateName_empty()
        {
            var dic = new Dictionary<string, object>();
            dic["corporateName"] = string.Empty;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Cnpj")]
        public void Cnpj_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic["cnpj"] = "14603191000190";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Company Name")]
        public void CorporateName_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic["corporateName"] = "Rua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua N66";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Fantasy Name")]
        public void FantasyName_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic["fantasyName"] = "Rua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua N66";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }


        [TestMethod("Invalid Street")]
        public void Invalid_street()
        {
            var dic = new Dictionary<string, object>();
            dic["street"] = "Rua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua NRua N66";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid City")]
        public void Invalid_city()
        {
            var dic = new Dictionary<string, object>();
            dic["city"] = "AracajuAracajuAracajuAracajuAracajuAracajuAracajuAracajuAracaju";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid State")]
        public void Invalid_state()
        {
            var dic = new Dictionary<string, object>();
            dic["state"] = "SER";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Country")]
        public void Invalid_country()
        {
            var dic = new Dictionary<string, object>();
            dic["country"] = "BRA";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid ZipCode")]
        public void Invalid_zipCode()
        {
            var dic = new Dictionary<string, object>();
            dic["zipCode"] = "49001-2795";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Number")]
        public void Invalid_number()
        {
            var dic = new Dictionary<string, object>();
            dic["number"] = "123456";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Email")]
        public void Invalid_Email()
        {
            var dic = new Dictionary<string, object>();
            dic["email"] = "representantes@as";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid PhoneList")]
        public void Invalid_PhoneList()
        {
            var list = new List<PhoneDTO>();
            list.Add(new PhoneDTO("795", "3971-957165"));

            var dic = new Dictionary<string, object>();
            dic["phoneList"] = list;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(2, validation.Count());
        }

        [TestMethod("Valid")]
        public void Valid()
        {
            var validation = FakeCommandValidate();

            Assert.AreEqual(false, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        private IResponse FakeCommandValidate(Dictionary<string, object> args = null) =>
            FakeCommand(args).Validate();

        private CreateCustomerPersonJurCommand FakeCommand(Dictionary<string, object> args = null) =>
            new CreateCustomerPersonJurCommand(
                cnpj: args != null && args.ContainsKey("cnpj") ? (string)args["cnpj"] : "14.603.191/0001-90",
                corporateName: args != null && args.ContainsKey("corporateName") ? (string)args["corporateName"] : "Luzia e Nelson Telecomunicações Ltda",
                fantasyName: args != null && args.ContainsKey("fantasyName") ? (string)args["fantasyName"] : "Luzia e Nelson Telecomunicações Ltda",
                street: args != null && args.ContainsKey("street") ? (string)args["street"] : "Rua N",
                city: args != null && args.ContainsKey("city") ? (string)args["city"] : "Aracaju",
                state: args != null && args.ContainsKey("state") ? (string)args["state"] : "SE",
                country: args != null && args.ContainsKey("country") ? (string)args["country"] : "BR",
                zipCode: args != null && args.ContainsKey("zipCode") ? (string)args["zipCode"] : "49001-279",
                number: args != null && args.ContainsKey("number") ? (string)args["number"] : "357",
                email: args != null && args.ContainsKey("email") ? (string)args["email"] : "representantes@luziaenelsontelecomunicacoesltda.com.br",
                phoneList: args != null && args.ContainsKey("phoneList") ? (List<PhoneDTO>)args["phoneList"] : FakeListPhone()
                );

        private List<PhoneDTO> FakeListPhone()
        {
            var list = new List<PhoneDTO>();
            list.Add(new PhoneDTO("79", "3971-9576"));
            list.Add(new PhoneDTO("79", "98864-1957"));
            return list;
        }
    }
}
