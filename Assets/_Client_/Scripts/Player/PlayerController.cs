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
        _positionCubeY = cubeTransform.position.y;
    }
    private void UseCubeZone()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_isUseCube)
            {
                _cubeTransform.DOMove(_cubePositionStack.position, _timeCubeUp);
                //_cubeTransform.position = _cubePositionStack.position;
                _cubeTransform.parent = transform;
                _isUseCube = true;
                
            }
            else
            {
                _cubeTransform.parent = null;                
                _isUseCube = false;
                _cubeTransform.DOMove(new Vector3(_cubeTransform.position.x, _positionCubeY, _cubeTransform.position.z), _timeCubeUp);
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
