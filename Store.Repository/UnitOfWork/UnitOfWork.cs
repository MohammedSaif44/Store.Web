using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.interfaces;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreDbContext context;
		private Hashtable repositories;
		public UnitOfWork(StoreDbContext context)
		{
			this.context = context;
		}

		public async Task<int> CompletedAsync()
		=> await context.SaveChangesAsync();

		public IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
		{
			if (repositories == null)
			{
				repositories = new Hashtable();
			}
			var entitykey = typeof(TEntity).Name;
			if (!repositories.ContainsKey(entitykey))
			{
				var repositoryType = typeof(GenericRepository<,>);//<product,int>(context)
				var RepositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity),typeof(Tkey)),context);
				repositories.Add(entitykey, RepositoryInstance);
			}
			return (IGenericRepository<TEntity, Tkey>)repositories[entitykey];
		}
	}
}
