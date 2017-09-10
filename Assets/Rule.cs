using System;
using System.Collections.Generic;
using System.Linq;
using ItFromBit.Rules;

public class Rule
{
    private readonly int m_rule;
    readonly int[] m_Results;

    public Rule(string definition)
    {
        m_rule = Convert.ToByte(definition, 2);
        
        // m_result is alookjup table will be storing values like this:
        // Rule0:
        // 0 1 2 3 4 5 6 7
        // 0 0 0 0 0 0 0 0 

        // Rule1:
        // 0 1 2 3 4 5 6 7
        // 1 0 0 0 0 0 0 0 

        // Rule2:
        // 0 1 2 3 4 5 6 7
        // 0 1 0 0 0 0 0 0 

        // Rule3:
        // 0 1 2 3 4 5 6 7
        // 1 1 0 0 0 0 0 0 

        // Rule4:
        // 0 1 2 3 4 5 6 7
        // 0 0 1 0 0 0 0 0 

        // Rule5:
        // 0 1 2 3 4 5 6 7
        // 1 0 1 0 0 0 0 0 
        m_Results = new int[8];

        for (var i = 0; i < definition.Length; ++i)
        {
            var mask = m_rule >> i;

            if ((mask & 1) == 1)
            {
                m_Results[i] = 1;
            }
        }
    }
    public IEnumerable<Cell> NextGeneration(IEnumerable<Cell> cells)
    {
        var result = new List<Cell>();
        var cellsArray = cells.ToArray();
        result.Add(new Cell("D"));
        for (var i = 1; i < cellsArray.Length - 1; ++i)
        {
            var left = (int)cellsArray[i - 1].State;
            var cell = (int)cellsArray[i].State;
            var right = (int)cellsArray[i + 1].State;
            var agregated = (left << 2) | (cell << 1) | right;
            var newState = m_Results[agregated];
            result.Add(new Cell(newState.ToString()));
        }
        result.Add(new Cell("D"));
        return result;
    }
}
