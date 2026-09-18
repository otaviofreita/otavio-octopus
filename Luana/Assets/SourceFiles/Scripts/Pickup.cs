using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Effects")]
    public GameObject particleEffectPrefab;

    [Header("Motion Settings")]
    public float rotationSpeed = 100f;
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 1f;

    private Vector3 startPosition;
    private float timer;
    private bool jaColetado = false; // Trava para impedir pontuação dupla

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        timer += Time.deltaTime * bobbingSpeed;
        float newY = startPosition.y + Mathf.Sin(timer) * bobbingAmount;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    public void Coletar(int playerIndex)
    {
        if (jaColetado) return;
        jaColetado = true;

        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }

        PlayerObserverManager.NotifyEstrelaCollected(playerIndex);
        Destroy(gameObject);
    }
}