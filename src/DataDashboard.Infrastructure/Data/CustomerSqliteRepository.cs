﻿using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataDashboard.Infrastructure.Data
{
    public class CustomerSqliteRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "sqlite";

        public CustomerSqliteRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM Customers" +
                                 " WHERE Id = @Id";
            try
            {
                var customer = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Id = id
                    }, ConnectionString);

                return customer.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Customer>> FindBySearch(string search)
        {
            string query = "SELECT * FROM Customers " +
                           "WHERE Name LIKE @Search";

            try
            {
                var result = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" + search + "%"
                    }, ConnectionString);

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Customer>> ListAllAsync()
        {
            const string query = "SELECT * FROM Customers";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                    }, ConnectionString);

                return customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Customer>> ListAllWithPaging(int page, int pageSize)
        {
            const string query = "SELECT * FROM Customers" +
                                 "LIMIT @PageSize OFFSET @Offset ";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, ConnectionString);

                return customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Customer>> ListAllWithSearchingAndPaging(string search, int page, int pageSize)
        {
            const string query = "SELECT * FROM ( SELECT * FROM Customers WHERE Name LIKE @Search ) Sub" +
                                 "ORDER BY Id LIMIT @PageSize OFFSET @Offset";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" + search + "%",
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, ConnectionString);

                return customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> Create(Customer entity)
        {
            const string query = "INSERT INTO Customers " +
                                 "(Name, Email, State) VALUES " +
                                 "(@Name, @Email, @State);";
            try
            {
                var customer = new
                {
                    entity.Name,
                    entity.Email,
                    entity.State
                };

                await _dataAccess.SaveData(query, customer, ConnectionString);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
