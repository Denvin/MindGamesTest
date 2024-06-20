using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speedMove;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveVector)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(moveVector.normalized);
        Vector3 offset = directionAlongSurface * _speedMove;

        _rigidbody.MovePosition(_rigidbody.position + offset * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, moveVector, 0.15f));

        //_unitAnimator.SetSpeedMove(_moveVector.magnitude);
    }
}
