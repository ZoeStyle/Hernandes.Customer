using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hernandes.Customer.Domain.Test.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod("Inform CNPJ for individual type document")]
        public void Document_fis_test_1()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "79.769.045/0001-85");

            var fakeDocument = FakeDocumentFis(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestMethod("Inform the CPF with incorrect characters")]
        public void Document_fis_test_2()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "15571875682");

            var fakeDocument = FakeDocumentFis(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestMethod("Inform the CPF with characters correctly")]
        public void Document_fis_test_3()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "155.718.756-82");

            var fakeDocument = FakeDocumentFis(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestMethod("Inform CPF for business type document")]
        public void Document_jur_test_1()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "155.718.756-82");

            var fakeDocument = FakeDocumentJur(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestMethod("Inform CNPJ with incorrect characters")]
        public void Document_jur_test_2()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "21036947000122");

            var fakeDocument = FakeDocumentJur(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(true, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        [TestMethod("Inform CNPJ with characters correctly")]
        public void Document_jur_test_3()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("documentNumber", "21.036.947/0001-22");

            var fakeDocument = FakeDocumentJur(dic);

            var validate = fakeDocument.Validate();

            Assert.AreEqual(false, validate.HasError());
            Assert.AreEqual(1, validate.Count());
        }

        private Document FakeDocumentJur(Dictionary<string, object> args = null) =>
            new Document(
                documentNumber: args != null && args.ContainsKey("documentNumber") ? (string)args["documentNumber"] : "21.036.947/0001-22",
                type: args != null && args.ContainsKey("type") ? (DocumentType)args["type"] : DocumentType.Juridica
                );

        private Document FakeDocumentFis(Dictionary<string, object> args = null) =>
            new Document(
                documentNumber: args != null && args.ContainsKey("documentNumber") ? (string)args["documentNumber"] : "155.718.756-82",
                type: args != null && args.ContainsKey("type") ? (DocumentType)args["type"] : DocumentType.Fisica
                );
    }
}
