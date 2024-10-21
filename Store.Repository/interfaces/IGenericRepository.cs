using Store.Data.Context;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.interfaces
{
	public interface IGenericRepository<TEntity,Tkey>where TEntity:BaseEntity<Tkey>
	{
		Task AddAsync(TEntity entity);
		Task<TEntity> GetByIdAsync(int id);
		 Task<IReadOnlyList<TEntity>> GetAllAsync();
		
		public void Update(TEntity entity);
		public void Delete(TEntity entity);

		

	} 
	
	
}
