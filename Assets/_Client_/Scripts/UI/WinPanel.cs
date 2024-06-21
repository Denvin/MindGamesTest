using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private Field _workField;
    [SerializeField]
    private Button _restartButton;

    private void Start()
    {
        _workField.OnWin += ActivatePanel;
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void ActivatePanel()
    {
        _winPanel.SetActive(true);
    }
    private void RestartGame()
    {
        ScenesLoader.Instance.Restart();
    }
}
