using MMT.Domain.Interfaces;
using MMT.Domain.Models;
using MMT.Infra.Data.Context;

namespace MMT.Infra.Data.Repository
{
    public class CellRepository : Repository<Cell>, ICellRepository
    {
        public CellRepository(MMTContext context):base(context)
        {
        }
    }
}
