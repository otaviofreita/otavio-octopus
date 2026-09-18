using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   public string sceneName;
   
   public void Load()
   {
     if (GameManager.Instance != null)
        {
            GameManager.Instance.RequestSceneChange(sceneName);
        }

        else
        {
            Debug.LogError("Game Manager nao achado");
        }
   }
}