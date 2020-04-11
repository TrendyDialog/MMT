using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Interfaces
{
    public interface IBagReplacementService : IDisposable
    {
        /// <summary>
        /// Get all entries
        /// </summary>
        /// <returns></returns>
        IEnumerable<BagReplacementViewModel> GetAll();

        /// <summary>
        /// Get select entries
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BagReplacementViewModel GetById(long id);

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="bagReplacementViewModel"></param>
        void Add(BagReplacementViewModel bagReplacementViewModel);

        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="bagReplacementViewModel"></param>
        void Update(BagReplacementViewModel bagReplacementViewModel);
    }
}
