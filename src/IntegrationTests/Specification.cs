using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using  Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DependencyResolution;
using StructureMap;

namespace  Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests {
    [TestFixture]
    public abstract class Specification {
		protected IContainer container;
        [TestFixtureSetUp]
        public void Setup() {
			container = IoC.Initialize(null);
			Arrange();
            Act();
        }

        protected virtual void Arrange() { }
        protected virtual void Act() { }

        [TestFixtureTearDown]
        public virtual void TearDown() {
			container.Dispose();
        }
    }
}
