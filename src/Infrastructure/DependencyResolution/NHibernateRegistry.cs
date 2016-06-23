using NHibernate;
using StructureMap.Configuration.DSL;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess;
using Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Impl;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DependencyResolution
{
	public class NHibernateRegistry : Registry
	{
		public NHibernateRegistry()
		{
			For<IRepository>().Transient().Use<Repository>();
			For<ISession>().Transient().Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
			For<ISessionFactory>().Singleton().Use(() => NHibernateHelper.BuildSessionFactory());
		}
	}
}
