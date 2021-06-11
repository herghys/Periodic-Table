using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeriodicSceneScript : MonoBehaviour
{
    public void ButtonCloseCard()
    {
        GameData.UpdateContextUI?.Invoke(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
