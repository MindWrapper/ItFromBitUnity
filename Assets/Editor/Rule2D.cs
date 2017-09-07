using System;

public class Rule2D
{
	private readonly int m_rule;
	readonly int[] m_results;

	public Rule2D(string definition)
	{
		m_rule = Convert.ToByte(definition, 2);
		m_results = new int[8];

		for (var i = 0; i < definition.Length; ++i)
		{
			var mask = m_rule >> i;

			if ((mask & 1) == 1)
			{
				m_results[i] = 1;
			}
		}
	}

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

	public int Apply (int value)
	{
		var res = m_results[value];
		return res;
	}
}
