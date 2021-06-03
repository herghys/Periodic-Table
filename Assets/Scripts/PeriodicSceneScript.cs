using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeriodicSceneScript : MonoBehaviour
{
    [SerializeField] GameUtility events;

    private void Start()
    {
        
    }

    public void ButtonCloseCard()
    {
        events.UpdateContextUI?.Invoke(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
