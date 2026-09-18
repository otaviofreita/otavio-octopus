using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Tela de Vitória")]
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    private void Start()
    {
        // Desativa o painel ao iniciar a cena GUI
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        // Se registra com o GameManager persistente vindo do _Boot
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegistrarUI(this);
        }
    }
}