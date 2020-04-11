using MMT.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace MMT.Service.Interfaces
{
    public interface IDamageTypeService : IDisposable
    {
        /// <summary>
        /// Get all entries
        /// </summary>
        /// <returns></returns>
        IEnumerable<DamageTypeViewModel> GetAll();

        /// <summary>
        /// Get select entries
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DamageTypeViewModel GetById(long id);

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="damageTypeViewModel"></param>
        void Add(DamageTypeViewModel damageTypeViewModel);

        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="damageTypeViewModel"></param>
        void Update(DamageTypeViewModel damageTypeViewModel);
    }
}
