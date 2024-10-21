using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
		Task<int> CompletedAsync();
	}
}
