using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeriodicManager : MonoBehaviour
{
    [SerializeField] GameUtility events;
    [SerializeField] bool isSideMenuOpen;

    public void ButtonCloseCard()
    {
        events.UpdateContextUI?.Invoke(false);
    }

    private void Start()
    {
        events.UpdateSideMenuUI?.Invoke(false);
    }

    public void SetSideMenu()
    {
        isSideMenuOpen = !isSideMenuOpen;
        events.UpdateSideMenuUI?.Invoke(isSideMenuOpen);
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    private void OnDestroy()
    {
        events.IsSelectedElement.Clear();
    }
}
