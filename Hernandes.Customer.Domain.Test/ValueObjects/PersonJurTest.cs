using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class PersonJurTest
    {
        [TestCategory("Person Jur")]
        [TestMethod("Company Name Empty")]
        public void CorporateName_Empy()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("corporateName", string.Empty);

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Jur")]
        [TestMethod("Company Name Null")]
        public void CorporateName_null()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("corporateName", null);

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Jur")]
        [TestMethod("Company Name Characters Invalid")]
        public void CorporateName_characters_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("corporateName", "Catarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira Ltda");

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Jur")]
        [TestMethod("Multi Errors")]
        public void Multi_errors()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("corporateName", "Catarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira Ltda");
            dic.Add("fantasyName", "Catarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira Ltda");

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(2, validate.Count());
        }



        [TestCategory("Person Jur")]
        [TestMethod("Fantasy Name Characters Invalid")]
        public void FantasyName_characters_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("fantasyName", "Catarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira LtdaCatarina e Pedro Henrique Financeira Ltda");

            var person = FakePerson(dic);

            var validate = person.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Person Jur")]
        [TestMethod("Valid")]
        public void Valid()
        {
            var person = FakePerson();

            var validate = person.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }


        private PersonJur FakePerson(Dictionary<string, object> args = null) =>
            new PersonJur(
                corporateName: args != null && args.ContainsKey("corporateName") ? (string)args["corporateName"] : "Catarina e Pedro Henrique Financeira Ltda",
                fantasyName: args != null && args.ContainsKey("fantasyName") ? (string)args["fantasyName"] : "Catarina e Pedro Henrique Financeira Ltda"
                );
    }
}
