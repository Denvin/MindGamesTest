using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private TypeCube _typeCube;

    public void SetType(TypeCube typeCube)
    {
        _typeCube = typeCube;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_typeCube == TypeCube.StaticCube) return;
        
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.EnterCubeZone(gameObject.transform);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_typeCube == TypeCube.StaticCube) return;

        if (other.TryGetComponent<PlayerController>(out PlayerController playerController) && !playerController.IsUseCube)
        {
            playerController.ExitCubeZone();

        }
    }
}
public enum TypeCube
{
    UsedCube,
    StaticCube
}
