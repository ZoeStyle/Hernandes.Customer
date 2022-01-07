using Hernandes.Customer.Application.Commands;
using Hernandes.Customer.Application.DTOs;
using Hernandes.Customer.Response.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hernandes.Customer.Application.Test.Commands
{
    [TestClass]
    public class UpdateCustomerPersonFisCommandTest
    {
        [TestMethod("Invalid Id")]
        public void Invalid_id()
        {
            var dic = new Dictionary<string, object>();
            dic["id"] = 0;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Name Null")]
        public void Name_null()
        {
            var dic = new Dictionary<string, object>();
            dic["name"] = null;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("CPF Null")]
        public void Cpf_null()
        {
            var dic = new Dictionary<string, object>();
            dic["cpf"] = null;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(2, validation.Count());
        }

        [TestMethod("Name Empty")]
        public void Name_empty()
        {
            var dic = new Dictionary<string, object>();
            dic["name"] = string.Empty;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("CPF Empty")]
        public void Cpf_empty()
        {
            var dic = new Dictionary<string, object>();
            dic["cpf"] = string.Empty;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(2, validation.Count());
        }

        [TestMethod("Invalid Name")]
        public void Invalid_name()
        {
            var dic = new Dictionary<string, object>();
            dic["name"] = "Tatiane Nair AlvesTatiane Nair AlvesTatiane Nair AlvesTatiane Nair Alves";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid CPF")]
        public void Invalid_cpf()
        {
            var dic = new Dictionary<string, object>();
            dic["cpf"] = "001.781.548-735";

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid RG")]
        public void Invalid_rg()
        {
            var dic = new Dictionary<string, object>();
            dic["rg"] = "15.538.974-95";

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

        [TestMethod("Invalid Gender")]
        public void Invalid_gender()
        {
            var dic = new Dictionary<string, object>();
            dic["gender"] = 4;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid Gender 02")]
        public void Invalid_gender_02()
        {
            var dic = new Dictionary<string, object>();
            dic["gender"] = 0;

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid BirthDay")]
        public void Invalid_birthDay()
        {
            var dic = new Dictionary<string, object>();
            dic["birthDay"] = DateTime.Now.AddDays(2);

            var validation = FakeCommandValidate(dic);

            Assert.AreEqual(true, validation.HasError());
            Assert.AreEqual(1, validation.Count());
        }

        [TestMethod("Invalid EmailList")]
        public void Invalid_EmailList()
        {
            var list = new List<EmailDTO>();
            list.Add(new EmailDTO("tatianenairalves__tatianenairalves"));

            var dic = new Dictionary<string, object>();
            dic["emailList"] = list;

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

        [TestMethod("MultiErrors")]
        public void MultiErrors()
        {
            var dic = new Dictionary<string, object>();
            dic["birthDay"] = DateTime.Now.AddDays(2);
            dic["gender"] = 0;

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

        private UpdateCustomerPersonFisCommand FakeCommand(Dictionary<string, object> args = null) =>
            new UpdateCustomerPersonFisCommand(
                id: args != null && args.ContainsKey("id") ? (int)args["id"] : 1,
                cpf: args != null && args.ContainsKey("cpf") ? (string)args["cpf"] : "001.781.548-73",
                name: args != null && args.ContainsKey("name") ? (string)args["name"] : "Tatiane Nair Alves",
                gender: args != null && args.ContainsKey("gender") ? (int)args["gender"] : 1,
                birthDay: args != null && args.ContainsKey("birthDay") ? (DateTime)args["birthDay"] : new DateTime(2002, 01, 03),
                rg: args != null && args.ContainsKey("rg") ? (string)args["rg"] : "15.538.974-9",
                street: args != null && args.ContainsKey("street") ? (string)args["street"] : "Rua N",
                city: args != null && args.ContainsKey("city") ? (string)args["city"] : "Aracaju",
                state: args != null && args.ContainsKey("state") ? (string)args["state"] : "SE",
                country: args != null && args.ContainsKey("country") ? (string)args["country"] : "BR",
                zipCode: args != null && args.ContainsKey("zipCode") ? (string)args["zipCode"] : "49001-279",
                number: args != null && args.ContainsKey("number") ? (string)args["number"] : "357",
                emailList: args != null && args.ContainsKey("emailList") ? (List<EmailDTO>)args["emailList"] : FakeListEmail(),
                phoneList: args != null && args.ContainsKey("phoneList") ? (List<PhoneDTO>)args["phoneList"] : FakeListPhone()
                );

        private List<EmailDTO> FakeListEmail()
        {
            var list = new List<EmailDTO>();
            list.Add(new EmailDTO("tatianenairalves__tatianenairalves@uol.com.br"));
            list.Add(new EmailDTO("tatianenairalves_tatianenairalves@uol.com.br"));
            list.Add(new EmailDTO("tatianenairalvestatianenairalves@uol.com.br"));
            list.Add(new EmailDTO("tatianenairalves@uol.com.br"));
            return list;
        }

        private List<PhoneDTO> FakeListPhone()
        {
            var list = new List<PhoneDTO>();
            list.Add(new PhoneDTO("79", "3971-9576"));
            list.Add(new PhoneDTO("79", "98864-1957"));
            return list;
        }
    }
}
