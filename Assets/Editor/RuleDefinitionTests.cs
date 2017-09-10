using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ItFromBit.Rules.Tests
{
    [TestFixture]
    public class RuleDefinitionTests
    {
        // First and last cells are always dead, alorithm
        // operates only on 'middile' cells
        [Test]
        [TestCase("0", "AAA", "DDD")]
        [TestCase("0", "AAAAAA", "DDDDDD")]
        [TestCase("1", "DDDD", "DAAD")]
        [TestCase("10", "DDD", "DDD")]
        [TestCase("10010", "DADDD", "DDADD")] // Rule18
        [TestCase("10010", "DDDAD", "DDADD")] // Rule18
        public void AppliesSelectedRulesCorrectly(string ruleDef, string cellDefs, string expectedCellDefs)
        {
            var resultCellDefs = Apply(new Rule(ruleDef), MakeCells(cellDefs));
            Assert.That(resultCellDefs, Is.EqualTo(expectedCellDefs));
        }

        private static string Apply(Rule r, IEnumerable<Cell> cells)
        {
            return MakeDefinition(r.NextGeneration(cells));
        }

        private static IEnumerable<Cell> MakeCells(string definition)
        {
            return definition.Select(c => new Cell(c.ToString())).ToList();
        }

        private static string MakeDefinition(IEnumerable<Cell> cells)
        {
            var res = new StringBuilder();
            foreach (var c in cells)
            {
                if (c.State == CellState.Alive)
                {
                    res.Append("A");
                    continue;
                }

                if (c.State == CellState.Dead)
                {
                    res.Append("D");
                    continue;
                }

                throw new Exception("Invalid cell state " + c.State);
            }

            return res.ToString();
        }
    }
}
