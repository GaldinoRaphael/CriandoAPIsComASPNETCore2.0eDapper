using FluentValidator;
using RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Inputs;
using RaphaStore.Domain.StoreContext.CostumerCommands.Inputs;
using RaphaStore.Shared.Commands;

namespace RaphaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        public CustomerHandler()
        {
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verficiar se cpf existe na base
            //Verificar se o e-mail já existe na abse
            //Criar VOs
            //Criar Entidade
            //Persistir o cliente
            //Enviar email de boas vindas
            //Retornar resultado para tela
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}