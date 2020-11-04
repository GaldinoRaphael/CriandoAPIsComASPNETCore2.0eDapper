using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Inputs;
using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Enums;
using RaphaStore.Domain.StoreContext.Handlers;
using RaphaStore.Domain.StoreContext.ValueObjects;

namespace RaphaStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void DeveRegistrarUmClienteQuandoOComandoEhValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Raphael";
            command.LastName = "Galdino";
            command.Email = "Galdino@inova.com.br";
            command.Document = "28659170377";
            command.Phone = "11999999999";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}