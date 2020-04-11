using MMT.Domain.Interfaces;
using MMT.Domain.Models;
using MMT.Infra.Data.Context;

namespace MMT.Infra.Data.Repository
{
    public class CellChangesRepository : Repository<CellChanges>, ICellChangesRepository
    {
        public CellChangesRepository(MMTContext context)
            :base(context)
        {
        }
    }
}
