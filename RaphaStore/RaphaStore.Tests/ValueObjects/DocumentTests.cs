using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RaphaStore.Tests
{
    [TestClass]
    public class DocumentTests
    {

        [TestMethod]
        public void DeveRetornarNotificationQuandoODocumentoNaoForValido()
        {
            var document = new Document("12345678910");
            Assert.AreEqual(false, document.IsValid);
            Assert.AreEqual(1, document.Notifications.Count);
        }
        [TestMethod]
        public void NaoDeveRetornarNotificationQuandoODocumentoForValido()
        {
            var document = new Document("997.454.700-82");
            Assert.AreEqual(true, document.IsValid);
            Assert.AreEqual(0, document.Notifications.Count);
        }
    }
}