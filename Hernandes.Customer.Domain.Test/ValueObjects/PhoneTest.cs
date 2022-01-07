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

            var dic = new Dictionary<string, object>();
            dic.Add("ddd",ddd);
            dic.Add("phoneNumber", number);

            var phone = FakePhone(dic);

            var validate = phone.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(2, validate.Count());
        }

        [TestCategory("Phone Test")]
        [TestMethod("Valid validation")]
        public void Valid()
        {
            var phone = FakePhone();

            var validate = phone.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private Phone FakePhone(Dictionary<string, object> args = null) =>
            new Phone(
                ddd: args != null && args.ContainsKey("ddd") ? (string)args["phoneNumber"] : "96",
                phoneNumber: args != null && args.ContainsKey("phoneNumber") ? (string)args["phoneNumber"] : "99817-7304"
                );
    }
}
