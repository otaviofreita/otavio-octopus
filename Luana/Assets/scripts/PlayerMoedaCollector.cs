using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMoedaCollector : MonoBehaviour
{
    public int playerIndex = -1; 

    [Header("Aumento de Velocidade (Moedas)")]
    [SerializeField] private float incrementoVelocidade = 0.5f;
    [SerializeField] private float velocidadeMaxima = 12.0f;

    private int moedaCount = 0;
    private ThirdPersonController controller;
    private HashSet<GameObject> objetosProcessados = new HashSet<GameObject>();

    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
        ObterPlayerIndex();
    }

    private void Start()
    {
        ObterPlayerIndex();
    }

    private void ObterPlayerIndex()
    {
        if (playerIndex < 0)
        {
            PlayerInput pInput = GetComponent<PlayerInput>();
            if (pInput != null)
            {
                playerIndex = pInput.playerIndex;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ProcessarColeta(hit.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ProcessarColeta(other.gameObject);
    }

    private void ProcessarColeta(GameObject item)
    {
        if (item == null) return;

        // Evita processar a mesma moeda ou estrela duas vezes
        if (objetosProcessados.Contains(item)) return;

        ObterPlayerIndex();

        // 1. MOEDA: Velocidade
        if (item.CompareTag("Moeda"))
        {
            objetosProcessados.Add(item);
            moedaCount++;
            
            AumentarVelocidade();
            PlayerObserverManager.NotifyMoedaCollected(playerIndex >= 0 ? playerIndex : 0);
            
            Destroy(item);
        }
        // 2. ESTRELA: Vitória
        else
        {
            Pickup pickup = item.GetComponent<Pickup>();
            if (pickup != null)
            {
                objetosProcessados.Add(item);
                pickup.Coletar(playerIndex >= 0 ? playerIndex : 0);
            }
        }
    }

    private void AumentarVelocidade()
    {
        if (controller != null)
        {
            controller.MoveSpeed = Mathf.Min(controller.MoveSpeed + incrementoVelocidade, velocidadeMaxima);
            controller.SprintSpeed = Mathf.Min(controller.SprintSpeed + incrementoVelocidade, velocidadeMaxima * 1.5f);
        }
    }
}