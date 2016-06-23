using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess
{
	public class NHibernateHelper
	{
		internal static ISessionFactory BuildSessionFactory()
		{
			return Fluently.Configure()
				.Database(OracleClientConfiguration.Oracle10
					.ConnectionString(c => c.FromConnectionStringWithKey("connectionString")))
					.Mappings(mapping => mapping.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
				.BuildSessionFactory();
		}

	}
}
