using System.Linq;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions
{
	public static class AssortmentAnalysisExtensions
	{
		public static IQueryable<AssortmentAnalysis> GetAllActiveAssortments(this IRepository repository)
		{
			return repository.Find<AssortmentAnalysis>().OrderByDescending(x => x.LastChanged);
		}

		public static AssortmentAnalysis GetActiveAssortment(this IRepository repository, int id)
		{
			return repository.GetAllActiveAssortments().FirstOrDefault(x => x.Id == id);
		}
	}
}
