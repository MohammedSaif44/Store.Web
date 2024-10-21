using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
	public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
	{
		private readonly StoreDbContext context;

		public GenericRepository(StoreDbContext context)
		{
			this.context = context;
		}

		public async Task AddAsync(TEntity entity)
		=> await context.Set<TEntity>().AddAsync(entity);

		public void Delete(TEntity entity)
		=>  context.Set<TEntity>().Remove(entity);

		public async Task<IReadOnlyList<TEntity>> GetAllAsync()
	     => await context.Set<TEntity>().ToListAsync();

		public async Task<TEntity> GetByIdAsync(int id)
		=> await context.Set<TEntity>().FindAsync(id);


		public void Update(TEntity entity)
		=> context.Set<TEntity>().Update(entity);
	}
}
