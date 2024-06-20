using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Joystick _joystick;

    private float _inputX;
    private float _inputZ;
    private Vector3 _moveVector;


    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _inputX = _joystick.Horizontal != 0 ? _joystick.Horizontal : Input.GetAxis("Horizontal");
        _inputZ = _joystick.Vertical != 0 ? _joystick.Vertical : Input.GetAxis("Vertical");
        _moveVector = new Vector3(_inputX, 0, _inputZ);

        _movement.Move(_moveVector);
    }
}
