using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;

    [SerializeField]
    private Joystick _joystick;

    [SerializeField]
    private Transform _cubePositionStack;

    [SerializeField]
    private float _timeCubeUp;

    private Transform _cubeTransform;

    private bool _isCubeZone;
    private bool _isUseCube;
    private float _inputX;
    private float _inputZ;
    private float _positionCubeY;
    private Vector3 _moveVector;

    public bool IsUseCube => _isUseCube;


    private void Update()
    {
        Move();
        if (_isCubeZone)
        {            
            UseCubeZone();
        }
    }
    public void EnterCubeZone(Transform cubeTransform)
    {
        _isCubeZone = true;
        _cubeTransform = cubeTransform;     
        
    }
    public void ExitCubeZone()
    {
        _isCubeZone = false;
    }
    private void UseCubeZone()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_isUseCube)
            {
                _positionCubeY = _cubeTransform.position.y;
                _cubeTransform.parent = transform;
                _cubeTransform.DOLocalMove(_cubePositionStack.localPosition, _timeCubeUp);
                _cubeTransform.localEulerAngles = Vector3.zero;
                _isUseCube = true;
                _movement.SpeedMoveBag();
            }
            else
            {
                _cubeTransform.parent = null;                
                _cubeTransform.DOMove(new Vector3(_cubeTransform.position.x, _positionCubeY, _cubeTransform.position.z), _timeCubeUp);
                _movement.SpeedMoveBase();
                _isUseCube = false;
            }
        }
    }
    private void Move()
    {
        _inputX = _joystick.Horizontal != 0 ? _joystick.Horizontal : Input.GetAxis("Horizontal");
        _inputZ = _joystick.Vertical != 0 ? _joystick.Vertical : Input.GetAxis("Vertical");
        _moveVector = new Vector3(_inputX, 0, _inputZ);

        _movement.Move(_moveVector);
    }

}
