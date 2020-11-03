using FluentValidator;
using FluentValidator.Validation;
using RaphaStore.Shared.Commands;

namespace RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Ouputs
{
    public class CreateCustomerCommand : ICommandResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}