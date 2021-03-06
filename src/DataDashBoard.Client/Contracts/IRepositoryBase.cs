﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDashboard.Client.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAll(string url);
        Task<T> GetSingle(string url, int id);
        Task<T> Create(string url, T entity);
        Task<T> Update(string url, T entity, int id);
        Task Delete(string url, int id);
    }
}