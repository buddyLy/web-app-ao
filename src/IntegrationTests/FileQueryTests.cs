using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.IntegrationTests
{
	public class When_getting_a_file : Behaves_like_Persistence_Spec
	{
		private int _capability;
		private short _fileType;
		private CapabilityFile _result;
		protected override void Arrange()
		{
			base.Arrange();
			_capability = 160;
			_fileType = 100;

		}

		protected override void Act()
		{
			_result = repository.Get<CapabilityFile>(x => x.Capability.Id == _capability && x.FileType.Code == _fileType);
		}

		[Test]
		public void It_should_match_what_was_requested()
		{
			Assert.That(_result.Capability.Id, Is.EqualTo(_capability));
			Assert.That(_result.FileType.Code, Is.EqualTo(_fileType));
		}

		[Test]
		public void It_should_not_have_null_content()
		{
			Assert.That(_result.Content, Is.Not.Null);
		}

		[Test]
		public void It_should_have_the_correct_type()
		{
			Assert.That(_result.FileType, Is.Not.Null);
			Assert.That(_result.FileType.Description(), Is.EqualTo("Diagnostic Item List"));
		}

	}
}
