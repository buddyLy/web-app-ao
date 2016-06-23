using System;
using System.Linq;
using System.Linq.Expressions;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces
{
	public interface IRepository
	{
		T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntity;
		IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : IEntity;
		IQueryable<T> Find<T>() where T : IEntity;
		T Save<T>(IEntity entity) where T : IEntity;
		void Delete<T>(IEntity entity) where T : IEntity;
		void SubmitChanges();
	}
}
