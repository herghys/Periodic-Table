using System.Collections;
using System.Collections.Generic;
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

        Debug.Log(gu.ElementData.Count);
        Debug.Log(gu.ElementData["Hydrogen"].AtomicMass);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
