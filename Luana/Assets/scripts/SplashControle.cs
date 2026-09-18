using System.Collections;
using UnityEngine;

public class SplashControle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitAndLoadMenu());
    }

    private IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.RequestSceneChange("Menu");
    }
}