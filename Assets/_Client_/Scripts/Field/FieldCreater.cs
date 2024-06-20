using UnityEngine;

public class FieldCreater : MonoBehaviour
{
    [SerializeField]
    private int _columns;

    [SerializeField]
    private int _lines;

    [SerializeField]
    private float _offset;

    [SerializeField]
    private Cell _cellPrefab;

    [SerializeField]
    private GameObject _fieldSprite;

    [SerializeField]
    private Field _field;

    private Cell _newCell;

    private Vector3 _currentPositionCell;
    private int _countByX = 1;

    private void Start()
    {
        SpawnField();
    }
    private void SpawnField()
    {
        //float sizeX = _columns * _cellPrefab.transform.localScale.x + _offset * (_columns + 1);
        //float sizeY = _lines * _cellPrefab.transform.localScale.y + _offset * (_lines + 1);
        float sizeX = _cellPrefab.transform.localScale.x * (_columns + 1);
        float sizeY = _cellPrefab.transform.localScale.y * (_lines + 1);


        _fieldSprite.transform.localScale = new Vector3(sizeX, sizeY);

        var startPositionX = -(_columns / 2 * _offset);
        var startPositionZ = _lines / 2 * _offset;
        
        var countCells = _columns * _lines;

        Vector3 spawnPosition = new Vector3(startPositionX, _fieldSprite.transform.position.y, startPositionZ);
        Vector3 position = spawnPosition;

        _newCell = Instantiate(_cellPrefab, spawnPosition, _cellPrefab.transform.rotation, transform);
        _newCell.transform.localPosition = spawnPosition;
        _field.AddCell(_newCell);

        for (int i = 1; i < countCells; i++)
        {
            if(_countByX < _columns)
            {
                spawnPosition.x += _offset;
                _countByX++;
            }
            else
            {
                spawnPosition.x = position.x;
                spawnPosition.z -= _offset;
                _countByX = 1;
            }
            _currentPositionCell = spawnPosition;
            
            
            _newCell = Instantiate(_cellPrefab, spawnPosition, _cellPrefab.transform.rotation, transform);
            _newCell.transform.localPosition = spawnPosition;
            _field.AddCell(_newCell);
        }
    }
}

