﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDashboard.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);
        
    }
}