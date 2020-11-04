using System;
using FluentValidator;
using FluentValidator.Validation;
using RaphaStore.Shared.Commands;

namespace RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Ouputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }
        public CreateCustomerCommandResult(Guid id,
                                            string name,
                                            string email)
        {
            Id = id;
            Name = name;
            Email = email;

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}