using System;

namespace MMT.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; private set; }
        public string User { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
