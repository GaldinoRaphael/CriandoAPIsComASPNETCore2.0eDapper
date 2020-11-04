using System;
using FluentValidator;
using RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Inputs;
using RaphaStore.Domain.StoreContext.Commands.CostumerCommands.Ouputs;
using RaphaStore.Domain.StoreContext.CostumerCommands.Inputs;
using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Repositories;
using RaphaStore.Domain.StoreContext.Services;
using RaphaStore.Domain.StoreContext.ValueObjects;
using RaphaStore.Shared.Commands;

namespace RaphaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
    Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verficiar se cpf existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este cpf já está em uso");
            //Verificar se o e-mail já existe na abse
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já existe na base de dados");
            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            //Criar Entidade
            var customer = new Customer(name, document, email, command.Phone);
            //Validar entidades e Vos
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            //Persistir o cliente
            if (IsValid)
                _repository.save(customer);
            //Enviar email de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Seja bem vindo ao balta store");

            //Retornar resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}