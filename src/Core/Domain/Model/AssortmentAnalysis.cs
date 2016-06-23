using System;
using System.Collections.Generic;
using System.Linq;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Extensions;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class AssortmentAnalysis : TrackedEntity
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Department { get; set; }
		public virtual RollupLevel Rollup { get; set; }
		public virtual DateTime? StartDate { get; set; }
		public virtual DateTime? EndDate { get; set; }

		private IList<Capability> _capabilities;
		public virtual IEnumerable<Capability> Capabilities { get { return _capabilities; } }

		public virtual void AddCapability(Capability capability)
		{
			capability.AssortmentAnalysis = this;
			_capabilities.Add(capability);
			UpdateAuditTrail(capability.Creator);
		}

		public virtual string Status
		{
			get
			{
				if (Capabilities.Any())
				{
					var mostRecent = Capabilities.OrderByDescending(x => x.LastChanged).FirstOrDefault();
					return string.Format(@"{0}-{1}", mostRecent.ShortName, mostRecent.Status.Description());
				}
				else
				{
					return string.Empty;
				}
			}
		}

		public AssortmentAnalysis()
		{
			StartDate = null;
			EndDate = null;
			_capabilities = new List<Capability>();
		}

        public AssortmentAnalysis(CreateAssortmentRequest req, string createdBy) : this()
        {
			Initialize(req.Department, req.Name, req.RollUpTypeCode, createdBy);
			//Every New Assortment Automatically gets a Diagnostic.
            var diag = new Diagnostic(Creator, CapabilityStatus.Waiting, req.GetItemListAsBytes());
            this.AddCapability(diag);
        }

		private void Initialize(int dept, string name, short rollupCode, string creator) {
			Name = name.RemoveSpecialCharacters().ToUpper();
			Department = dept;
			Creator = creator;
			Rollup = new RollupLevel { Code = rollupCode };
			Created = DateTime.Now;
			UpdateAuditTrail(creator);
		}
	}
}
