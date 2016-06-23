using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public abstract class Localization : IEntity, IEquatable<Localization>
	{
		public virtual short Code { get; set; }
		public virtual string LanguageCode { get; set; }
		public virtual string Description { get; set; }

		public override int GetHashCode()
		{
			unchecked
			{
				return (Code * 397) ^ (LanguageCode == null ? 0 : LanguageCode.GetHashCode());
			}
		}
		public override bool Equals(object obj)
		{
			return Equals(obj as Localization);
		}
		public virtual bool Equals(Localization other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Code == other.Code && Equals(LanguageCode, other.LanguageCode);
		}
	}
}
