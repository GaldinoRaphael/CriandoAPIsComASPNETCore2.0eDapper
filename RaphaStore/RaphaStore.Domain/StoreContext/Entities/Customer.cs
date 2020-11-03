using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using RaphaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Costumer : Notifiable
    {
        private readonly IList<Address> _address;
        public Costumer(
        Name name,
        Document document,
        Email email,
        string phone
        )
        {
            Name = name;
            Document = document;
            Email = email;
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _address.ToArray();

        public void AddAdress(Address address)
        {
            _address.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}