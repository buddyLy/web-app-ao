using System;
using System.IO;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks
{
	internal static class FileMocker
	{
		public static byte[] GetBytes(string sampleFileName) 
		{
			return File.ReadAllBytes(string.Format(@"Files\{0}", sampleFileName));
		}

		public static string GetFileString(string sampleFileName) 
		{
			return Convert.ToBase64String(GetBytes(sampleFileName));
		}
	}
}
