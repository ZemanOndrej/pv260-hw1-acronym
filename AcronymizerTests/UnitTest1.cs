using System.Collections.Generic;
using Acronymizer;
using NUnit.Framework;

namespace Tests
{
	public class Tests
	{
		[Test]
		public void Test_empty_string()
		{
			Assert.AreEqual(AcronymParser.CreateAcronym(""), "");
		}

		[Test]
		public void Test_empty_null()
		{
			Assert.AreEqual(AcronymParser.CreateAcronym(null), null);
		}


		[Test]
		public void Test_simple_strings()
		{
			Assert.AreEqual(AcronymParser.CreateAcronym("Don't repeat yourself"), "DRY");
			Assert.AreEqual(AcronymParser.CreateAcronym("Asynchronous Javascript and XML"),
				"AJAX");
		}

		[Test]
		public void Test_dash_strings()
		{
			Assert.AreEqual(AcronymParser.CreateAcronym("Complementary metal-oxide semiconductor"),
				"CMOS");
			Assert.AreEqual(AcronymParser.CreateAcronym("Random-Name-Thing"),
				"RNT");
		}

		[Test]
		public void Test_config_with_and()
		{
			Assert.AreEqual(
				AcronymParser.CreateAcronym("Rhythm and blues", processString: (str =>
						str.Replace("and", "&")
					)),
				"R&B");
		}

		[Test]
		public void Test_config_with_and_within_word()
		{
			Assert.AreEqual(
				AcronymParser.CreateAcronym("hand leg", processString: (str =>
						str.Replace("and", "&")
					)),
				"HL");
		}
	}
}