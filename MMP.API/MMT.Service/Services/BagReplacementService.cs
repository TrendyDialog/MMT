using AutoMapper;
using MMT.Domain.Core.Bus;
using MMT.Domain.Interfaces;
using MMT.Service.Interfaces;
using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Services
{
    public class BagReplacementService : IBagReplacementService
    {
        private readonly IBagReplacementRepository bagReplacementRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public BagReplacementService(IBagReplacementRepository bagReplacementRepository, IMapper mapper, IBus bus)
        {
            this.bagReplacementRepository = bagReplacementRepository;
            this.bus = bus;
            this.mapper = mapper;
        }        

        public IEnumerable<BagReplacementViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BagReplacementViewModel GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Add(BagReplacementViewModel bagReplacementViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(BagReplacementViewModel bagReplacementViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
