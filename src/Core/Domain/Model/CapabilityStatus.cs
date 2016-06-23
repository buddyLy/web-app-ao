using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public static class CapabilityStatus
    {
        public static Status Error = new Status() { Code = 1 };

        public static Status Waiting = new Status() { Code = 2 };

        public static Status Active = new Status() { Code = 3 };

        public static Status Done = new Status() { Code = 4 };
    }
}
