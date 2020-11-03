using System;
using System.Collections.Generic;
using System.Linq;
using RaphaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Costumer
    {
        private readonly IList<Address> _address;
        public Costumer(
        Name name,
        string document,
        string email,
        string phone,
        string adress)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _address = new List<Address>();
        }
        public Name Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
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