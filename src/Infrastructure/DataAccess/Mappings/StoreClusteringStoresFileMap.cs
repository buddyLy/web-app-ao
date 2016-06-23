﻿using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class StoreClusteringStoresFileMap : SubclassMap<StoreClusteringStoresListFile>
    {
        public StoreClusteringStoresFileMap()
        {
            DiscriminatorValue(300);
        }
    }
}