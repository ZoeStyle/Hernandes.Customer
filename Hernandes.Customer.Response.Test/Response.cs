using Hernandes.Customer.Response.Contracts;
using Hernandes.Customer.Response.Test.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Response.Test
{
    [TestClass]
    public class Response
    {
        [TestCategory("Response Validation")]
        [TestMethod("Requires a string is a cpf number valid")]
        public void ResponseOk()
        {
            var document = new Document("694.546.650-73");

            var result = document.Validate();

            Assert.AreEqual(false, result.HasError());
        }

        [TestCategory("Response Validation")]
        [TestMethod("Requires a string is a cpf number invalid")]
        public void ResponseError()
        {
            var document = new Document("69454665073");

            var result = document.Validate();

            Assert.AreEqual(true, result.HasError());
            Assert.AreEqual(1, result.Count());
        }
    }
}
