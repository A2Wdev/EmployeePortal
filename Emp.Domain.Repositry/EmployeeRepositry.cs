using Emp.Domain.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Emp.Domain.Repositry
{
	public class EmployeeRepositry : IRepositry
	{
		private readonly EmployeeContext _context;
		
		public EmployeeRepositry(EmployeeContext dbContext)
		{
			_context = dbContext;
		}

		public IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> pridicate) where TEntity : class
		{
			var result = _context.Set<TEntity>().AsQueryable();

			return result.AsNoTracking().Where(pridicate).ToList();
		}

		public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
		{
			var result = _context.Set<TEntity>().Add(entity);
			return result.Entity;
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
