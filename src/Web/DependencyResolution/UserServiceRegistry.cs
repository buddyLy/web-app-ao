using StructureMap.Configuration.DSL;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.DependencyResolution
{
    public class UserServiceRegistry : Registry
    {
        public UserServiceRegistry()
        {
            For<IUserService>().Transient().Use<UserService>();
        }
    }
}