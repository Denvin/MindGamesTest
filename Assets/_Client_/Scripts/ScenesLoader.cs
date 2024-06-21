using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesLoader : MonoBehaviour
{


    #region SingleTon

    public static ScenesLoader Instance { get; private set; }



    private void Awake()

    {

        if (Instance != null)

        {

            Destroy(gameObject);

        }

        else

        {

            Instance = this;

        }

    }

    #endregion



    public void Restart()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentIndex);
        
    }


}

