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

            var fakeEmail = FakeEmail(address);

            var validate = fakeEmail.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Invalid Characters")]
        public void Invalid_characters_test_2()
        {
            var address = "enzothomascardoso";

            var fakeEmail = FakeEmail(address);

            var validate = fakeEmail.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Empty")]
        public void Empty()
        {
            var fakeEmail = FakeEmail(string.Empty);

            var validate = fakeEmail.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestCategory("Email Test")]
        [TestMethod("Valid")]
        public void Valid()
        {
            var fakeEmail = FakeEmail();

            var validate = fakeEmail.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private Email FakeEmail(string address = null) =>
            new Email(
                address: address != null ? address : "enzothomascardoso@beminvestir.com.br"
                );
    }
}
