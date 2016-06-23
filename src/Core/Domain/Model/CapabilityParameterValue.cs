using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CapabilityParameterValue : TrackedEntity, IEquatable<CapabilityParameterValue>
    {
        public virtual CapabilityParameter Parameter { get; set; }

        public virtual string Value { get; set; }

        public virtual Capability Capability { get; set; }

        public CapabilityParameterValue()
        {
        }

        public CapabilityParameterValue(CapabilityParameter param, string value, string createdBy)
        {
            Parameter = param;
            Value = value;
            DateTime now = DateTime.Now;
            this.Creator = createdBy;
            this.Created = now;
			UpdateAuditTrail(createdBy);
        }

        public virtual bool Equals(CapabilityParameterValue other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
            return Equals(Parameter == other.Parameter) && Equals(Capability, other.Capability);
		}
		public override bool Equals(object obj)
		{
            return Equals(obj as CapabilityParameterValue);
		}
		public override int GetHashCode()
		{
			unchecked
			{
                return (Capability == null ? 0 : Capability.GetHashCode()) ^ (Parameter == null ? 0 : Parameter.GetHashCode());
			}
		}
    }
}
