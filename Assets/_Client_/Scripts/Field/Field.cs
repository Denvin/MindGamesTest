using System.Collections.Generic;
using UnityEngine;
using System;

public class Field : MonoBehaviour
{
    [SerializeField] private TypeField _typeField;
    [SerializeField] private FieldController _fieldController;

    private List<Cell> _cells = new List<Cell>();

    public event Action OnWin;

    private void OnEnable()
    {
        
        SpawnCubes();
    }
    private void OnDisable()
    {
        if (_typeField == TypeField.WorkField)
        {
            
            foreach (var cell in _cells)
            {
                cell.OnCubeEntered -= CheckTrueCell;
                cell.OnCubeExited -= CheckTrueCell;
            }
        }
    }
    private void Start()
    {
        if (_typeField == TypeField.WorkField)
        {
            SetTrueCell();
            foreach (var cell in _cells)
            {
                cell.OnCubeEntered += CheckTrueCell;
                cell.OnCubeExited += CheckTrueCell;
            }
        }
    }
    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
    }

    private void SpawnCubes()
    {
        switch (_typeField)
        {
            case TypeField.ExampleField:
                SpawnRandomCubes();
                break;
            case TypeField.WorkField:
                
                break;
            case TypeField.PoolField:
                SpawnPoolCubes();
                break;
        }
    }

    private void SetTrueCell()
    {
        for (int i = 0; i < _fieldController.TrueIndexes.Count; i++)
        {
            _cells[_fieldController.TrueIndexes[i]].IsCheckCellTrue = true;            
        }
        foreach (var cell in _cells)
        {
            cell.IsCheckCell = true;
        }
    }
    private void CheckTrueCell()
    {
        var countTrueCell = 0;
        var countHasCubeCell = 0;
        foreach (var cell in _cells)
        {
            if (cell.IsTrueCell)
            {
                countTrueCell++;
            }
            else if (cell.IsHasCube)
            {
                countHasCubeCell++;
            }
        }
        
        if (countTrueCell == _fieldController.TrueIndexes.Count && countHasCubeCell == 0)
        {
            OnWin?.Invoke();
        }
    }
    private void SpawnRandomCubes()
    {
        bool isSpawn;
        for(int i = 0; i < _cells.Count; i++)
        {
            isSpawn = UnityEngine.Random.value > 0.5f;

            if (isSpawn)
            {
                _cells[i].SpawnStaticCube();
                _fieldController.SetIndexes(i);
            }
        }

    }
    
    private void SpawnPoolCubes()
    {
        foreach (var cell in _cells)
        {
            cell.SpawnUsedCube();
        }
    }
}


public enum TypeField
{
    ExampleField,
    WorkField,
    PoolField
}