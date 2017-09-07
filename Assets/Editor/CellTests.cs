using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using ItFromBit.Rules;

public class RulesTests
{
		[Test]
		public void Create_DeadCell_ConstructsIt()
		{
		 	Assert.That( new Cell2D("D").State, Is.EqualTo(CellState.Dead));
		}

		[Test]
		public void Create_AliveCell_ConstructsIt ()
		{
			Assert.That (new Cell2D ("A").State, Is.EqualTo (CellState.Alive));
		}

		[Test]
		public void Create_InvalidStateString_ThrowsException ()
		{
			Assert.That( () => new Cell2D ("C"), Throws.Exception );
		}

}
