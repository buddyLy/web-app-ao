using System;
using System.Collections.Generic;
using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public abstract class Capability : TrackedEntity
	{
		public virtual int Id { get; set; }
		public virtual AssortmentAnalysis AssortmentAnalysis { get; set; }
		public virtual Status Status { get; set; }
		public virtual string StatusMessage { get; set; }
		public virtual string ShortName { get { return string.Empty; } }

        private IList<CapabilityFile> _files;
        public virtual IEnumerable<CapabilityFile> Files { get { return _files.AsEnumerable(); } }

        private IList<CapabilityParameterValue> _parameters;

        public virtual IEnumerable<CapabilityParameterValue> Parameters { get { return _parameters.AsEnumerable(); } }


        public Capability()
        {
            _files = new List<CapabilityFile>();
            _parameters = new List<CapabilityParameterValue>();
        }

        public Capability(string createdBy, Status status) : this()
        {
            var now = DateTime.Now;
            Creator = createdBy;
            Created = now;
            Status = new Status {Code = status.Code};
            UpdateAuditTrail(createdBy);
        }

	    protected virtual void AddCapabilityFile(CapabilityFile file)
        {
            file.Capability = this;
            _files.Add(file);
			UpdateAuditTrail(file.Creator);
        }

	    protected virtual void SetCapabilityParameterValue(CapabilityParameterValue paramValue)
        {
            paramValue.Capability = this;
            _parameters.Add(paramValue);
            UpdateAuditTrail(paramValue.Creator);
        }
	}
}
