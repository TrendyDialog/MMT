using MMT.Domain.Core.Commands;
using System;

namespace MMT.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
