using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Domain.core
{
	public interface IRepositry
	{
		IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, Boolean>> pridicate) where TEntity  : class;

		TEntity  Insert<TEntity>(TEntity entity ) where TEntity : class;

		void SaveChanges();  
	}

	  
}
