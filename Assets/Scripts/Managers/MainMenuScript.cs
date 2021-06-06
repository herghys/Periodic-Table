using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameUtility gu;

    private void Awake()
    {
        if (gu.ElementData.Count > 1)
        {
            gu.ElementData.Clear();
        }
    }
    void Start()
    {
        Object[] objs = Resources.LoadAll("ElementsData", typeof(Element));
        foreach (Element item in objs)
        {
            gu.ElementData.Add(item.name, item);
        }
    }

    public void LoadScene(string sceneName)
    {
        LoadingEvents.SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
