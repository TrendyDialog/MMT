using MMT.Domain.Interfaces;
using MMT.Domain.Models;
using MMT.Infra.Data.Context;

namespace MMT.Infra.Data.Repository
{
    public class BagReplacementRepository : Repository<BagReplacement>, IBagReplacementRepository
    {
        public BagReplacementRepository(MMTContext context)
            :base(context)
        {
        }
    }
}
