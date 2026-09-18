using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class GeradorPlayer : MonoBehaviour
{
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private Transform spawnPointP1;
    [SerializeField] private Transform spawnPointP2;

    private void Awake()
    {
        if (inputManager == null)
            inputManager = GetComponent<PlayerInputManager>();
    }

    private void Start()
    {
        InstanciarJogadores();
        StartCoroutine(AguardarEAtualizarEstrelas());
    }

    public void InstanciarJogadores()
    {
        if (inputManager == null || inputManager.playerPrefab == null) return;

        // Player 1
        PlayerInput p1 = inputManager.JoinPlayer(
            playerIndex: 0,
            splitScreenIndex: -1,
            controlScheme: "Keyboard P1",
            pairWithDevice: Keyboard.current
        );

        // Player 2
        PlayerInput p2 = inputManager.JoinPlayer(
            playerIndex: 1,
            splitScreenIndex: -1,
            controlScheme: "Keybord P2",
            pairWithDevice: Keyboard.current
        );

        ConfigurarJogador(p1, 0, spawnPointP1, OutputChannels.Channel01);
        ConfigurarJogador(p2, 1, spawnPointP2, OutputChannels.Channel02);
    }

    private void ConfigurarJogador(PlayerInput player, int index, Transform spawn, OutputChannels channel)
    {
        if (player == null) return;

        if (spawn != null)
        {
            player.transform.position = spawn.position;
            player.transform.rotation = spawn.rotation;
        }

        // Atribui explicitamente o índice do jogador ao coletor
        PlayerMoedaCollector collector = player.GetComponent<PlayerMoedaCollector>();
        if (collector != null)
        {
            collector.playerIndex = index;
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AllocatePlayerInput(player);
        }

        CinemachineCamera vcam = player.GetComponentInChildren<CinemachineCamera>();
        if (vcam != null)
        {
            vcam.OutputChannel = channel;
        }

        CinemachineBrain brain = player.GetComponentInChildren<CinemachineBrain>();
        if (brain != null)
        {
            brain.ChannelMask = channel;
        }
    }

    private IEnumerator AguardarEAtualizarEstrelas()
    {
        yield return null;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.estrelasColetadasTotal = 0;
            GameManager.Instance.p1Score = 0;
            GameManager.Instance.p2Score = 0;

            Pickup[] estrelas = FindObjectsByType<Pickup>(FindObjectsSortMode.None);
            GameManager.Instance.totalEstrelasNaCena = estrelas.Length;

            Debug.Log($"[SISTEMA] Estrelas encontradas na cena: {estrelas.Length}");
        }
    }
}