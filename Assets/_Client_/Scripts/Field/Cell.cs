using UnityEngine;
using System;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Cube _cubePrefab;
    [SerializeField]
    private float _spawnPositionY;
    [SerializeField]
    private Color _trueColor;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private Cube _cube;
    private Color _baseColor;
    private bool _isCheckCellTrue;
    private bool _isTrueCell;
    private bool _isCheckCell;
    private bool _isHasCube;

    public bool IsHasCube => _isHasCube;
    public bool IsTrueCell => _isTrueCell;

    public bool IsCheckCell
    {
        get { return _isCheckCell; }
        set { _isCheckCell = value; }
    }
    public bool IsCheckCellTrue
    {
        get { return _isCheckCellTrue; }
        set { _isCheckCellTrue = value; }
    }

    public event Action OnCubeEntered;
    public event Action OnCubeExited;


    private void Start()
    {
        _baseColor = _spriteRenderer.color;
    }
    public void SpawnStaticCube()
    {
        _cube = Instantiate(_cubePrefab, new Vector3(transform.position.x, _spawnPositionY, transform.position.z), Quaternion.identity);
        _cube.SetType(TypeCube.StaticCube);        
    }
    public void SpawnUsedCube()
    {
        _cube = Instantiate(_cubePrefab, new Vector3(transform.position.x, _spawnPositionY, transform.position.z), Quaternion.identity);
    }

    public void SetTrueCell()
    {
        _isTrueCell = true;
        _spriteRenderer.color = _trueColor;
    }
    public void SetBaseCell()
    {
        _isTrueCell = false;
        _spriteRenderer.color = _baseColor;
    }
    private void OnTriggerEnter(Collider other)
    {        
        if(other.TryGetComponent<Cube>(out Cube cube) && _isCheckCell)
        {
            if (_isCheckCellTrue)
            {
                SetTrueCell();
            }
            else
            {
                _isHasCube = true;
            }
            OnCubeEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Cube>(out Cube cube) && _isCheckCellTrue)
        {
            SetBaseCell();
            OnCubeExited?.Invoke();
        }
    }
}
