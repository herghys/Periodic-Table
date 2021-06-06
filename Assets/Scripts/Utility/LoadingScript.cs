using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

[Serializable()]
public struct LoadingUI
{
    public Slider LoadingSlider;
    public Image LoadingFill;
    public TextMeshProUGUI LoadingText;
}

[RequireComponent(typeof(Slider))]
public class LoadingScript : MonoBehaviour
{
    [SerializeField] GameUtility gu;
    [SerializeField] LoadingUI loadingUI;

    private string _scene;
    private float _progress = 0f;
    private void Awake()
    {
        loadingUI.LoadingSlider = GetComponent<Slider>();
        loadingUI.LoadingText = GetComponentInChildren<TextMeshProUGUI>();

        _scene = LoadingEvents.SceneToLoad;
        loadingUI.LoadingSlider.value = 0;
    }

    void Start()
    {
        if (!string.IsNullOrEmpty(_scene))
            StartCoroutine(LoadAsync(_scene));
    }

    IEnumerator LoadAsync(string scene)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);

        while (!op.isDone)
        {
            _progress = Mathf.Clamp01((op.progress / 0.9f));
            loadingUI.LoadingText.text = ( _progress * 100f).ToString() + "%";
            loadingUI.LoadingSlider.value = _progress;
            yield return null;
        }
    }
}
