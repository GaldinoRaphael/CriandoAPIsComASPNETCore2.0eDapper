using System;
using System.Collections.Generic;

namespace RaphaStore.Domain.StoreContext.Commands.OrderCommands
{
    public class PlaceOrderCommand
    {
        public Guid Custumer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}