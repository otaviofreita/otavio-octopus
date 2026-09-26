using TMPro;
using UnityEngine;

public class ControladorCoin : MonoBehaviour
{
    [Header("Configuração do Jogador")]
    [Tooltip("0 para Player 1 | 1 para Player 2")]
    [SerializeField] private int targetPlayerIndex = 0;

    [Header("Referência de Texto")]
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnMoedaCollected += UpdateCoinText;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnMoedaCollected -= UpdateCoinText;
    }

    private void Start()
    {
        AtualizarTexto(0);
    }

    private void UpdateCoinText(int totalMoedas)
    {
        if (GameManager.Instance != null)
        {
            int pontuacaoJogador = (targetPlayerIndex == 0) ? GameManager.Instance.p1Score : GameManager.Instance.p2Score;
            AtualizarTexto(pontuacaoJogador);
        }
        else
        {
            AtualizarTexto(totalMoedas);
        }
    }

    private void AtualizarTexto(int valor)
    {
        if (coinText != null)
        {
            string prefixo = "Moedas: ";
            coinText.text = prefixo + valor;
        }
    }
}