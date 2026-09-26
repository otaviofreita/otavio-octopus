using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    [Header("Tela de Vitória")]
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegistrarUI(this);
        }
    }
}