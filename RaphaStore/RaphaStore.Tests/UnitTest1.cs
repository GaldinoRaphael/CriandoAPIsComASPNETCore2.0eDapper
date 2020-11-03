using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaphaStore.Domain.StoreContext.ValueObjects;

namespace RaphaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Raphael", "Galdino");
            var document = new Document("12345679811");
            var email = new Email("Rua Jabuticaba, 69");
            var costumer = new Costumer(
                name,
                document,
                email,
                "19999999999"
                );
            var mouse = new Product("Mouse", "Rato", "img.png", 59, 99M);
            var impressora = new Product("Impressora", "Printer", "img.png", 359, 99M);
            var teclado = new Product("Teclado", "Teclado", "img.png", 359, 99M);
            var cadeira = new Product("Cadeira", "Cadeira", "img.png", 559, 99M);
            var order = new Order(costumer);
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));

            order.Place();

            var valid = order.IsValid;

            order.Pay();

            order.Ship();

            order.Cancel();
        }
    }
}
