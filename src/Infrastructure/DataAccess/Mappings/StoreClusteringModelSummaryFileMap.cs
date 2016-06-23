﻿using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class StoreClusteringModelSummaryFileMap : SubclassMap<StoreClusteringModelSummaryFile>
    {
        public StoreClusteringModelSummaryFileMap()
        {
            DiscriminatorValue(302);
        }
    }
}
