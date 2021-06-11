using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Awake()
    {
        if (GameData.ElementData.Count > 1) GameData.ElementData.Clear();
    }
    void Start()
    {
        Object[] objs = Resources.LoadAll("ElementsData", typeof(Element));
        foreach (Element item in objs)
        {
            GameData.ElementData.Add(item.name, item);
        }
    }

    public void LoadScene(string sceneName)
    {
        GameData.SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}