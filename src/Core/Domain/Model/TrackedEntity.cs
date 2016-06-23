using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public abstract class TrackedEntity : IEntity
	{
		public virtual string Creator { get; set; }
		public virtual DateTime Created { get; set; }
		public virtual string LastChangedBy { get; set; }
		public virtual DateTime LastChanged { get; set; }

		protected void UpdateAuditTrail(string user) {
			LastChangedBy = user;
			LastChanged = DateTime.Now;
		}
	}
}
