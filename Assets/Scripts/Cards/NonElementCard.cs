using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class NonElementCard : MonoBehaviour
{
    [SerializeField] GameUtility gameUtility;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] ElementType mType;
    [SerializeField] TextMeshProUGUI childText;

    Color baseWhite = new Color32(255, 255, 255, 255);
    Color disabledText = new Color32(173, 173, 173, 173);

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
        if (childText == null) childText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetUI(bool state)
    {
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;

        if (state) childText.color = baseWhite;
        else childText.color = disabledText;
    }

    private void SelectedType()
    {
        SetUI(gameUtility.IsSelectedElement[mType]);
    }
}