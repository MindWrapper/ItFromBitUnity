using System.Collections;
using System.Collections.Generic;
using ItFromBit.Rules;
using UnityEngine;


public class DisplayCells : MonoBehaviour
{
    public Color deadColor = Color.black;
    public Color alliveColor = Color.white;
    public int generationSize = 1000;
    public int generationsCount = 100;

    void Start()
    {
        var rule = new Rule("10010");
        var cells = new List<Cell>();
        for (int i = 0; i < generationSize; ++i)
        {
            cells.Add(new Cell("D"));
        }

        cells[cells.Count / 2].State = CellState.Alive;
        DisplayRowOfCells(cells, 0);

        for (var i = 0; i < generationsCount; i++)
        {
            cells = new List<Cell>(rule.NextGeneration(cells));
            DisplayRowOfCells(cells, -i - 1);
            Debug.Log("generation" + i);
        }
    }

    private void DisplayRowOfCells(IEnumerable<Cell> cells, int y)
    {
        var x = 0;
        foreach (var cell in cells)
        {
            if (cell.State == CellState.Alive)
            {
                var obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
                obj.GetComponent<Renderer>().material.color = alliveColor;
                obj.transform.position = new Vector3(x, y, 0);
            }
            ++x;
        }
    }
}
