namespace ItFromBit.Rules
{
	public class Cell2D
	{
		public Cell2D(string state)
		{
			State = state.FromString();
		}

		public CellState State { get; set; }
	}
}
