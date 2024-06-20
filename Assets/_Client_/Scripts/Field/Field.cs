using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private TypeField _typeField;

    private List<Cell> _cells = new List<Cell>();


    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
    }

}


public enum TypeField
{
    ExampleField,
    TaskField,
    PoolField
}