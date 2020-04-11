using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Interfaces
{
    public interface ICellService : IDisposable
    {
        /// <summary>
        /// Get all entries
        /// </summary>
        /// <returns></returns>
        IEnumerable<CellViewModel> GetAll();

        /// <summary>
        /// Get Cell by Name
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        IEnumerable<CellViewModel> GetCellByName(string cellName);

        /// <summary>
        /// Get select entries
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CellViewModel GetById(long id);

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="teamViewModel"></param>
        void Add(CellViewModel cellViewModel);

        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="teamViewModel"></param>
        void Update(CellViewModel cellViewModel);
    }
}

