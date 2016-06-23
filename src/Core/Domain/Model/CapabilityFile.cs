using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CapabilityFile : TrackedEntity, IEquatable<CapabilityFile>
	{
		public virtual Capability Capability { get; set; }
		public virtual FileType FileType { get; set; }
		public virtual byte[] Content { get; set; }

		public virtual bool Equals(CapabilityFile other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return FileType == other.FileType && Equals(Capability, other.Capability);
		}
		public override bool Equals(object obj)
		{
			return Equals(obj as CapabilityFile);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return (Capability == null ? 0 : Capability.GetHashCode()) ^ (FileType == null ? 0 : FileType.GetHashCode());
			}
		}

        public CapabilityFile()
        {
        }

        public CapabilityFile(byte[] file, FileType type, string creator):this()
        {
            Content = file;
            FileType = type;
            Creator = creator;
            Created = DateTime.Now;
            UpdateAuditTrail(creator);
        }
	}
}
