using AutoMapper;
using MMT.Domain.Commands.Cell;
using MMT.Domain.Core.Bus;
using MMT.Domain.Interfaces;
using MMT.Service.Interfaces;
using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Services
{
    public class CellService : ICellService
    {
        private readonly ICellRepository cellRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public CellService(ICellRepository cellRepository, IMapper mapper, IBus bus)
        {
            this.cellRepository = cellRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all entries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CellViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<CellViewModel>>(cellRepository.GetAll());
        }

        public IEnumerable<CellViewModel> GetCellByName(string cellName)
        {
            return mapper.Map<IEnumerable<CellViewModel>>(cellRepository.Find(x => x.CellName == cellName));
        }

        /// <summary>
        /// Get select an entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CellViewModel GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Add a new entry
        /// </summary>
        /// <param name="cellViewModel"></param>
        public void Add(CellViewModel cellViewModel)
        {
            var addCommand = mapper.Map<AddCellCommand>(cellViewModel);
            bus.SendCommand(addCommand);
        }

        /// <summary>
        /// Update an entry
        /// </summary>
        /// <param name="cellViewModel"></param>
        public void Update(CellViewModel cellViewModel)
        {
            var updateCommand = mapper.Map<UpdateCellCommand>(cellViewModel);
            bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
