using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class AddressTest
    {
        [TestCategory("Address Test")]
        [TestMethod("Street invalid")]
        public void Street_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("street", "Rua Octávio GobbiRua Octávio GobbiRua Octávio GobbiRua Octávio Gobbi");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1,validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("City invalid")]
        public void City_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("city", "ColatinaColatinaColatinaColatinaColatinaColatinaColatinaColatina");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("State invalid")]
        public void State_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("state", "ESP");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("Country invalid")]
        public void Country_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("country", "ESP");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("ZipCode invalid")]
        public void ZipCode_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("zipCode", "29702-7525");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("Multi Errors")]
        public void Multi_errors()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("state", "ESP");
            dic.Add("country", "BRA");
            dic.Add("zipCode", "29702-7525");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(3, validate.Count());
        }


        [TestCategory("Address Test")]
        [TestMethod("Number invalid")]
        public void Number_invalid()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("number", "1234567");

            var fakeAddress = FakeAddress(dic);

            var validate = fakeAddress.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Address Test")]
        [TestMethod("Valid Test")]
        public void Valid()
        {
            var fakeAddress = FakeAddress();

            var validate = fakeAddress.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private Address FakeAddress(Dictionary<string, object> args = null) =>
            new Address(
                street: args != null && args.ContainsKey("street") ? (string)args["street"] : "Rua Octávio Gobbi",
                city: args != null && args.ContainsKey("city") ? (string)args["city"] : "Colatina",
                state: args != null && args.ContainsKey("state") ? (string)args["state"] : "ES",
                country: args != null && args.ContainsKey("country") ? (string)args["country"] : "BR",
                zipCode: args != null && args.ContainsKey("zipCode") ? (string)args["zipCode"] : "29702-752",
                number: args != null && args.ContainsKey("number") ? (string)args["number"] : "870"
                );
    }
}
