using System;
using NUnit.Framework;

namespace ItFromBit.Rules.Tests
{
	[TestFixture]
	public class RuleDefinitionTests
	{
		[Test]
		public void Apply_Rule0_ReturnsZerroForAllCombinations ()
		{
			var rule = new Rule2D ("0");
			Assert.That (rule.Apply (1), Is.EqualTo (0));
			Assert.That (rule.Apply (0), Is.EqualTo (0));
		}

		[Test]
		public void Apply_Rule1_ReturnsOneOnlyforZerro ()
		{
			var rule = new Rule2D ("1");
			Assert.That (rule.Apply (0), Is.EqualTo (1));
			Assert.That (rule.Apply (1), Is.EqualTo (0));
		}

		[Test]
		public void Apply_Rule2_ReturnsOneOnlyforOne ()
		{
			var rule = new Rule2D ("10");
			Assert.That (rule.Apply (0), Is.EqualTo (0));
			Assert.That (rule.Apply (1), Is.EqualTo (1));
			Assert.That (rule.Apply (2), Is.EqualTo (0));
			Assert.That (rule.Apply (3), Is.EqualTo (0));
		}

		[Test]
		public void Apply_Rule3_ReturnsOneForOneAndTwo ()
		{
			var rule = new Rule2D ("11");
			Assert.That (rule.Apply (0), Is.EqualTo (1));
			Assert.That (rule.Apply (1), Is.EqualTo (1));
			Assert.That (rule.Apply (2), Is.EqualTo (0));
			Assert.That (rule.Apply (3), Is.EqualTo (0));
		}

		[Test]
		public void Apply_Rule4_ReturnsOneTwo ()
		{
			var rule = new Rule2D ("100");
			Assert.That (rule.Apply (0), Is.EqualTo (0));
			Assert.That (rule.Apply (1), Is.EqualTo (0));
			Assert.That (rule.Apply (2), Is.EqualTo (1));
			Assert.That (rule.Apply (3), Is.EqualTo (0));
		}

		[Test]
		public void Apply_Rule5_ReturnsFor3And1 ()
		{
			var rule = new Rule2D ("101");
			Assert.That (rule.Apply (0), Is.EqualTo (1));
			Assert.That (rule.Apply (1), Is.EqualTo (0));
			Assert.That (rule.Apply (2), Is.EqualTo (1));
			Assert.That (rule.Apply (3), Is.EqualTo (0));
		}


		[Test]
		public void Apply_Rule255_ReturnsFor3And1 ()
		{
			var rule = new Rule2D ("11111111");
			Assert.That (rule.Apply (0), Is.EqualTo (1));
			Assert.That (rule.Apply (1), Is.EqualTo (1));
			Assert.That (rule.Apply (2), Is.EqualTo (1));
			Assert.That (rule.Apply (3), Is.EqualTo (1));
			Assert.That (rule.Apply (4), Is.EqualTo (1));
			Assert.That (rule.Apply (5), Is.EqualTo (1));
			Assert.That (rule.Apply (6), Is.EqualTo (1));
			Assert.That (rule.Apply (7), Is.EqualTo (1));
		}

		private int ToInt(string rule)
		{
			return Convert.ToInt32(rule, 2);
		}
	}
}
