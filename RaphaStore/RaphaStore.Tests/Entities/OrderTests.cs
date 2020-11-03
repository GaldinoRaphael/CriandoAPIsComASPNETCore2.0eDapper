using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Enums;
using RaphaStore.Domain.StoreContext.ValueObjects;

namespace RaphaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Costumer _costumer;
        private Order _order;
        private Product _teclado;
        private Product _mouse;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Baltiere", "Santos");
            var document = new Document("797.154.310-70");
            var email = new Email("rapha@io.com.br");
            _costumer = new Costumer(name, document, email, "999999999");
            _teclado = new Product("Teclado", "Teclado", "img.png", 100M, 10);
            _mouse = new Product("Mouse", "Mouse", "img.png", 100M, 10);
            _chair = new Product("Chair", "Chair", "img.png", 100M, 10);
            _monitor = new Product("Monitor", "Monitor", "img.png", 100M, 10);
            _order = new Order(_costumer);
        }
        [TestMethod]
        public void DevoCriarUmPedidoQuandoValido()
        {
            Assert.AreEqual(true, _order.IsValid);
        }
        [TestMethod]
        public void DeveRetornarDoisQuandoAdicionarDoisItensValidos()
        {
            _order.AddItem(_teclado, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }
        [TestMethod]
        public void DeveRetornarCincoQuandoAdicionadoUmItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }
        [TestMethod]
        public void DeveRetornarUmNumeroQuandoForRealizadoUmPedido()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }
        [TestMethod]
        public void DeveRetornarPagoQuandoUmPedidoForPago()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void DeveRetornarDoisQuandoComprar10Produtos()
        {
            _order.AddItem(_teclado, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusDeveSerCanceladoQuandoUmPedidoForCancelado()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }
        [TestMethod]
        public void DeveSerCanceladoAsEntregasQuandoUmPedidoForCancelado()
        {
            _order.AddItem(_teclado, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();

            foreach (var Order in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, Order.Status);
            }
        }
    }
}