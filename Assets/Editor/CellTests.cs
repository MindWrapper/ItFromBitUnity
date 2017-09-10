using NUnit.Framework;
using ItFromBit.Rules;

public class RulesTests
{
    [Test]
    public void Create_DeadCell_ConstructsIt()
    {
        Assert.That(new Cell("D").State, Is.EqualTo(CellState.Dead));
        Assert.That(new Cell("0").State, Is.EqualTo(CellState.Dead));
    }

    [Test]
    public void Create_AliveCell_ConstructsIt()
    {
        Assert.That(new Cell("A").State, Is.EqualTo(CellState.Alive));
        Assert.That(new Cell("1").State, Is.EqualTo(CellState.Alive));
    }

    [Test]
    public void Create_InvalidStateString_ThrowsException()
    {
        Assert.That(() => new Cell("C"), Throws.Exception);
    }

}
