using System;

namespace ItFromBit.Rules
{
	public enum CellState
	{
		Dead = 0,
		Alive = 1
	}

	public static class CellStateExt
	{
		public static CellState FromString (this string state)
		{
			if (state == "A")
			{
				return CellState.Alive;
			}

			if (state == "D")
			{
				return CellState.Dead;
			}

			throw new Exception (string.Format ("Invalid cell state string {0}", state));
		}
	}
}