using TMPro;
using UnityEngine;

public class CoinControlerUI : MonoBehaviour
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

    // A assinatura bate exatamente com Action<int>
    private void UpdateCoinText(int totalMoedas)
    {
        // Lê a pontuação atual do jogador direto do GameManager persitente
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
            string prefixo = (targetPlayerIndex == 0) ? "Moedas: " : "Moedas: ";
            coinText.text = prefixo + valor;
        }
    }
}