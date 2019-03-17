using Acronymizer;
using NUnit.Framework;

namespace Tests
{
	public class Tests
	{
		private AcronymParser parser { get; set; }

		[SetUp]
		public void Setup()
		{
			this.parser = new AcronymParser();
		}

		[Test]
		public void Test_empty_string()
		{
			Assert.AreEqual(this.parser.CreateAcronym(""), "");
		}

		[Test]
		public void Test_empty_null()
		{
			Assert.AreEqual(this.parser.CreateAcronym(null), null);
		}


		[Test]
		public void Test_simple_strings()
		{
			Assert.AreEqual(this.parser.CreateAcronym("Don't repeat yourself"), "DRY");
			Assert.AreEqual(this.parser.CreateAcronym("Asynchronous Javascript and XML"),
				"AJAX");
		}

		[Test]
		public void Test_dash_strings()
		{
			Assert.AreEqual(this.parser.CreateAcronym("Complementary metal-oxide semiconductor"),
				"CMOS");
			Assert.AreEqual(this.parser.CreateAcronym("Random-Name-Thing"),
				"RNT");
			
		}

		[Test]
		public void Test_config_with_and()
		{
			this.parser.ReplaceOpts.Add(("and", "&"));
			Assert.AreEqual(this.parser.CreateAcronym("Rhythm and blues"), "R&B");
		}

		[Test]
		public void Test_config_with_and_within_word()
		{
			this.parser.ReplaceOpts.Add(("and", "&"));
			Assert.AreEqual(this.parser.CreateAcronym("hand leg"), "HL");
		}
	}
}