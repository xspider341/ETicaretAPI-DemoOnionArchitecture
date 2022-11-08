﻿using ETicaretAPI.Application.Repostories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repostories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        => Table;
        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
         => Table.Where(method);
        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method)
          => await Table.FirstOrDefaultAsync(method);
        public async Task<T> GetByIdAsync(string id)      
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        
    }
}
