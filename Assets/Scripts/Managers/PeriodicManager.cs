using UnityEngine;
using UnityEngine.SceneManagement;

public class PeriodicManager : MonoBehaviour
{
    private bool isSideMenuOpen;
    public void ButtonCloseCard()
    {
        GameData.UpdateContextUI?.Invoke(false);
    }

    private void Start()
    {
        GameData.UpdateSideMenuUI?.Invoke(false);
    }

    public void SetSideMenu()
    {
        isSideMenuOpen = !isSideMenuOpen;
        GameData.UpdateSideMenuUI?.Invoke(isSideMenuOpen);
    }

    public void LoadScene(string sceneName)
    {
        GameData.SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void OnDestroy()
    {
        GameData.IsSelectedElement.Clear();
    }
}
