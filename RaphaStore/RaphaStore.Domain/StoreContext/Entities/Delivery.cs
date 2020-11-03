using System;
using System.Collections.Generic;
using RaphaelStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimaredDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimaredDeliveryDate = estimaredDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; set; }
        public DateTime EstimaredDeliveryDate { get; set; }
        public EDeliveryStatus Status { get; set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }
    }
}