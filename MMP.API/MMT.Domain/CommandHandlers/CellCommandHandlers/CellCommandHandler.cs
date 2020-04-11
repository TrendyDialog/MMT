using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using MMT.Domain.Models;
using MMT.Domain.Core.Bus;
using MMT.Domain.Core.Events;
using MMT.Domain.Core.Notifications;
using MMT.Domain.Interfaces;
using MMT.Domain.Commands.Cell;

namespace MMT.Domain.CommandHandlers.CellCommandHandlers
{
    public class CellCommandHandler : CommandHandler, IHandler<AddCellCommand>, IHandler<UpdateCellCommand>
    {
        private readonly IHttpContextAccessor accessor;
        private readonly IMapper mapper;
        private readonly IBus bus;
        private readonly ICellRepository cellRepository;

        public CellCommandHandler(IHttpContextAccessor accessor,
                                                 IUnitOfWork uow,
                                                 IBus bus,
                                                 IMapper mapper,
                                                 IConfiguration Configuration,
                                                 IDomainNotificationHandler<DomainNotification> notifications,
                                                 ICellRepository cellRepository)
            : base(uow, bus, notifications)
        {
            this.bus = bus;
            this.accessor = accessor;
            this.mapper = mapper;
            this.cellRepository = cellRepository;
        }

        public void Handle(AddCellCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            if (message != null)
            {
                cellRepository.Add(mapper.Map<Cell>(message));
            }
            else
            {
                bus.RaiseEvent(new DomainNotification(message.MessageType, $"The Cell sent was empty."));
                return;
            }

            if (Commit())
            {
                //Raise Events
            }
        }

        public void Handle(UpdateCellCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            if (message != null)
            {
                cellRepository.Update(mapper.Map<Cell>(message));
            }
            else
            {
                bus.RaiseEvent(new DomainNotification(message.MessageType, $"The Cell sent was empty."));
                return;
            }

            if (Commit())
            {
                //Raise Events
            }
        }
    }
}
