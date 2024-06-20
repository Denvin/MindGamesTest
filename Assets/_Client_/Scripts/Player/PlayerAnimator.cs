using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeedMove(float speed)
    {
        _animator.SetFloat("SpeedMove", speed);
    }
}
