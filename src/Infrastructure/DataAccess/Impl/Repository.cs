using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Impl
{
	public class Repository : IRepository
	{
		private readonly ISession _session;
		public Repository(ISession session)
		{
			session.FlushMode = FlushMode.Always;
			session.BeginTransaction();
			_session = session;
		}

		public T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntity
		{
			return Find<T>(predicate).FirstOrDefault();
		}

		public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : IEntity
		{
			return Find<T>().Where(predicate);
		}

		public IQueryable<T> Find<T>() where T : IEntity
		{
			return _session.Query<T>();
		}

		public T Save<T>(IEntity entity) where T : IEntity
		{
			_session.SaveOrUpdate(entity);
			return (T)entity;
		}
		public void Delete<T>(IEntity entity) where T : IEntity
		{
			_session.Delete(entity);
		}
		public void SubmitChanges()
		{
		    _session.Transaction.Commit();
		    _session.BeginTransaction();
		}
	}
}
