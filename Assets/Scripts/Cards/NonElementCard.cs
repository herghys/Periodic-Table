using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class NonElementCard : MonoBehaviour
{
    [SerializeField] GameUtility gameUtility;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] ElementType mType;
    private void OnEnable()
    {
        gameUtility.UpdateUnselectedType += SelectedType;
    }

    private void OnDisable()
    {
        gameUtility.UpdateUnselectedType -= SelectedType;
    }
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void SetUI(bool state)
    {
        if (state)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    private void SelectedType()
    {
        SetUI(gameUtility.IsSelectedElement[mType]);
    }
}
