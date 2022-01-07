using Hernandes.Customer.Notifications.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hernandes.Customer.Notifications.Tests
{
    [TestClass]
    public class DocumentValidationTests
    {
        [TestCategory("Document Validation")]
        [TestMethod("Requires a string is a passport number")]
        public void IsPassport()
        {
            var contract = new Contract<string>()
                .Requires()

                // INVALID
                .IsPassport(null, "TEST 01")
                .IsPassport(null, "TEST 02", "Custom error message")

                // INVALID
                .IsPassport(string.Empty, "TEST 03")
                .IsPassport(string.Empty, "TEST 04", "Custom error message")

                // INVALID
                .IsPassport(" ", "TEST 05")
                .IsPassport(" ", "TEST 06", "Custom error message")

                // VALID
                .IsPassport("ABCDE", "TEST 07")
                .IsPassport("ABCDE", "TEST 08", "Custom error message")

                // VALID
                .IsPassport("1340", "TEST 09")
                .IsPassport("1340", "TEST 10", "Custom error message")

                // INVALID
                .IsPassport("587.461.400-18", "TEST 11")
                .IsPassport("587.461.400-18", "TEST 12", "Custom error message")

                // INVALID
                .IsPassport("774 451 480 78", "TEST 13")
                .IsPassport("774 451 480 78", "TEST 14", "Custom error message")

                // VALID
                .IsPassport("48042595034", "TEST 15")
                .IsPassport("48042595034", "TEST 16", "Custom error message")

                // VALID
                .IsPassport("48042595035", "TEST 15")
                .IsPassport("48042595035", "TEST 16", "Custom error message")

                // VALID
                .IsPassport("35245678901", "TEST 15")
                .IsPassport("35245678901", "TEST 16", "Custom error message")

                // INVALID
                .IsPassport("3524567890135245678901", "TEST 15")
                .IsPassport("3524567890135245678901", "TEST 16", "Custom error message");

            Assert.AreEqual(false, contract.IsValid);
            Assert.AreEqual(contract.Notifications.Count, 12);
        }

        [TestCategory("Document Validation")]
        [TestMethod("Requires a string is a cpf number")]
        public void IsCPF()
        {
            var contract = new Contract<string>()
                .Requires()

                // INVALID
                .IsCPF(string.Empty, "Teste 01")
                .IsCPF(string.Empty, "Teste 02")
                .IsCPF(string.Empty, "Teste 03")

                // INVALID
                .IsCPF(null, "Teste 04", "Custom error message")
                .IsCPF(null, "Teste 05", "Custom error message")

                // INVALID
                .IsCPF("69454665073", "Teste 06", "Custom error message")
                .IsCPF("20278772072", "Teste 07", "Custom error message")

                // VALID
                .IsCPF("694.546.650-73", "Teste 08")
                .IsCPF("202.787.720-72", "Teste 09")

                // VALID
                .IsCPF("694.546.650-73", "Teste 10", "Custom error message")
                .IsCPF("202.787.720-72", "Teste 11", "Custom error message");

            Assert.AreEqual(false, contract.IsValid);
            Assert.AreEqual(contract.Notifications.Count, 7);
        }

        [TestCategory("Document Validation")]
        [TestMethod("Requires a string is a cnpj number")]
        public void IsCNPJ()
        {
            var contract = new Contract<string>()
                .Requires()

                // INVALID
                .IsCNPJ(string.Empty, "Teste 01")
                .IsCNPJ(string.Empty, "Teste 02")
                .IsCNPJ(string.Empty, "Teste 03")

                // INVALID
                .IsCNPJ(null, "Teste 04", "Custom error message")
                .IsCNPJ(null, "Teste 05", "Custom error message")

                // INVALID
                .IsCNPJ("88164461000140", "Teste 06", "Custom error message")
                .IsCNPJ("27436447000164", "Teste 07", "Custom error message")

                // VALID
                .IsCNPJ("88.164.461/0001-40", "Teste 08")
                .IsCNPJ("27.436.447/0001-64", "Teste 09")

                // VALID
                .IsCNPJ("88.164.461/0001-40", "Teste 10", "Custom error message")
                .IsCNPJ("27.436.447/0001-64", "Teste 11", "Custom error message");

            Assert.AreEqual(false, contract.IsValid);
            Assert.AreEqual(contract.Notifications.Count, 7);
        }

        [TestCategory("Document Validation")]
        [TestMethod("Requires a string is a rg number")]
        public void IsRg()
        {
            var contract = new Contract<string>()
                .Requires()

                // INVALID
                .IsRG(string.Empty, "Teste 01")
                .IsRG(string.Empty, "Teste 02", "Custom error message")
                .IsRG(string.Empty, "Teste 03")

                // INVALID
                .IsRG(null, "Teste 04")
                .IsRG(null, "Teste 05", "Custom error message")

                // INVALID
                .IsRG("278293517", "Teste 06")
                .IsRG("278293517", "Teste 07", "Custom error message")

                // VALID
                .IsRG("27.829.351-75", "Teste 08")
                .IsRG("27.829.351-75", "Teste 09", "Custom error message")

                // VALID
                .IsRG("27.829.351-7", "Teste 10")
                .IsRG("27.829.351-7", "Teste 11", "Custom error message");


            Assert.AreEqual(false, contract.IsValid);
            Assert.AreEqual(contract.Notifications.Count, 9);
        }


    }
}
