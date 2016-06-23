using StructureMap;
using StructureMap.Graph;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize(IRegistrationConvention[] conventions)
        {
            const string namespaceRoot = "Walmart.Assortment.AssortmentOptimizationSystem";
            var container = new Container();
            container.Configure(c => c.Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory(a => a.GetName().Name.Contains(namespaceRoot));
                if (conventions != null)
                {
                    foreach (var convention in conventions)
                    {
                        x.With(convention);
                    }
                }
                x.LookForRegistries();
            }));
            //var whatigot = container.WhatDoIHave();
            return container;
        }
    }
}