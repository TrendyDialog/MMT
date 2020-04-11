using MMT.Domain.Core.Commands;
using MMT.Domain.Core.Events;

namespace MMT.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
