using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class PersonFisTest
    {
        [TestCategory("Person Fis Test")]
        [TestMethod("Name Empty")]
        public void Name_empty()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("name", string.Empty);

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Fis Test")]
        [TestMethod("Name Null")]
        public void Name_null()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("name", null);

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Fis Test")]
        [TestMethod("Name Characters Invalid")]
        public void Name_characters_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("name", "Simone Tereza Isabel das NevesSimone Tereza Isabel das Nevesa");

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Fis Test")]
        [TestMethod("BirthDay Invalid")]
        public void BirthDay_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("birthDay", DateTime.Now.AddDays(3));

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Fis Test")]
        [TestMethod("RG Invalid")]
        public void Rg_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("rg", "36.726.777-95");

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Fis Test")]
        [TestMethod("RG Invalid")]
        public void Valid()
        {
            var person = FakePerson();

            var validate = person.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private PersonFis FakePerson(Dictionary<string, object> args = null) =>
            new PersonFis(
                name: args != null && args.ContainsKey("name") ? (string)args["name"] : "Simone Tereza Isabel das Neves",
                gender: args != null && args.ContainsKey("gender") ? (Gender)args["gender"] : Gender.Feminino,
                birthDay: args != null && args.ContainsKey("birthDay") ? (DateTime)args["birthDay"] : new DateTime(1944, 9, 14),
                rg: args != null && args.ContainsKey("rg") ? (string)args["rg"] : "36.726.777-9"
                );
    }
}
