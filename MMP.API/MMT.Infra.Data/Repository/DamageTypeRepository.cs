using MMT.Domain.Interfaces;
using MMT.Domain.Models;
using MMT.Infra.Data.Context;

namespace MMT.Infra.Data.Repository
{
    public class DamageTypeRepository : Repository<DamageType>, IDamageTypeRepository
    {
        public DamageTypeRepository(MMTContext context) 
            :base(context)
        {
        }
    }
}
