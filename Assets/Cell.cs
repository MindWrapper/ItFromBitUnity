namespace ItFromBit.Rules
{
	public class Cell
	{
		public Cell(string state)
		{
			State = state.FromString();
		}

		public CellState State { get; set; }
	}
}
