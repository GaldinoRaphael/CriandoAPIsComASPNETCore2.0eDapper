using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using RaphaStore.Domain.StoreContext.Enums;
using RaphaStore.Shared.Entities;

namespace RaphaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");

            var item = new OrderItem(product, quantity);

            product.DecreaseQuantityOnHand(quantity);

            _items.Add(item);
        }

        //To Place An Order
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //Validar
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui items");
        }

        public void Pay()
        {
            //Validação
            Status = EOrderStatus.Paid;

        }
        public void Ship()
        {
            //A cada cinco produtos é uma entrega
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    _deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));
        }
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}