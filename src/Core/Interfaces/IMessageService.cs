using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces
{
    public interface IMessageService
    {
		Guid Send<T>(T message) where T : CapabilityMessage;
    }
}
