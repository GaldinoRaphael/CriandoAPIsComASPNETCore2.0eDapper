using System;
using System.Collections.Generic;
using System.Linq;
using RaphaelStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Costumer costumer)
        {
            Costumer = costumer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Costumer Costumer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();


        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        //To Place An Order
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //Validar
        }

        public void Pay()
        {
            //Validação
            Status = EOrderStatus.Paid;

        }
        public void Ship()
        {
            //A cada cinco produtos é uma entrega
            var count = 1;

            foreach (var item in _itens)
            {
                count++;
            }
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            _deliveries.Add(delivery);
            _deliveries.Ship();
        }
        public void Cancel() { }
    }
}