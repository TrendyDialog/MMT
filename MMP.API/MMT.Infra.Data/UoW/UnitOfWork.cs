using MMT.Domain.Core.Commands;
using MMT.Domain.Interfaces;
using MMT.Infra.Data.Context;

namespace MMT.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMTContext _context;

        public UnitOfWork(MMTContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
