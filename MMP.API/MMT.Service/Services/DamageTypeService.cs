using AutoMapper;
using MMT.Domain.Core.Bus;
using MMT.Domain.Interfaces;
using MMT.Service.Interfaces;
using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Services
{
    public class DamageTypeService : IDamageTypeService
    {
        private readonly IDamageTypeRepository damageTypeRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public DamageTypeService(IDamageTypeRepository damageTypeRepository, IMapper mapper, IBus bus)
        {
            this.damageTypeRepository = damageTypeRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        public IEnumerable<DamageTypeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DamageTypeViewModel GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Add(DamageTypeViewModel damageTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(DamageTypeViewModel damageTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
