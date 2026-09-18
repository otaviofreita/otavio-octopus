using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class RobotMovement : MonoBehaviour
{
    private StarterAssetsInputs starterInputs;

    private void Awake()
    {
        // Pega o componente StarterAssetsInputs na raiz
        starterInputs = GetComponent<StarterAssetsInputs>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (starterInputs != null)
        {
            // Repassa o movimento para o Starter Assets
            starterInputs.MoveInput(context.ReadValue<Vector2>());
        }
    }
}