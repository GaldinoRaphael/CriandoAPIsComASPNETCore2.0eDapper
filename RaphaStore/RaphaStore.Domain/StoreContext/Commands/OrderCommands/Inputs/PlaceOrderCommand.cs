using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using RaphaStore.Shared.Commands;

namespace RaphaStore.Domain.StoreContext.Commands.OrderCommands
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Indentificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "OrderItem", "Nenhum item do pedido foi encontrado")
  );
            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}