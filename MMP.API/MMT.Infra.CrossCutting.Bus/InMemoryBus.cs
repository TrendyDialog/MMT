﻿using MMT.Domain.Core.Bus;
using MMT.Domain.Core.Commands;
using MMT.Domain.Core.Events;
using MMT.Domain.Core.Notifications;
using System;

namespace MMT.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            if (!theEvent.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(theEvent);

            Publish(theEvent);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }

        // ReSharper disable once UnusedMember.Local
        private object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }

        // ReSharper disable once UnusedMember.Local
        private T GetService<T>()
        {
            return (T)Container.GetService(typeof(T));
        }
    }
}