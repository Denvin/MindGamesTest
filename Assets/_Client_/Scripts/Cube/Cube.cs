using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.EnterCubeZone(gameObject.transform);
        }
    }
}
