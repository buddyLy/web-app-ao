using System.Linq;
using System.Text;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions
{
	public static class StringExtensions
	{
		public static string RemoveSpecialCharacters(this string str)
		{
			const string validChars = @"~!@#$%^&*()_-+=<>?/|\[]{},. ";
			var sb = new StringBuilder();
			foreach (var c in str.Where(
                c => (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||
                validChars.Contains(c)))
			{
			    sb.Append(c);
			}
			return sb.ToString();
		}
	}
}
