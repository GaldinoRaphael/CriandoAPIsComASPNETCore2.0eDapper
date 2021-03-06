using System;
using System.Collections.Generic;
using FluentValidator;
using RaphaStore.Domain.StoreContext.Enums;
using RaphaStore.Shared.Entities;

namespace RaphaStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
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
        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}