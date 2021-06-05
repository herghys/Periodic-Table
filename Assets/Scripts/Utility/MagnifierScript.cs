using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class MagnifierScript : MonoBehaviour
{
    [SerializeField] ScrollRect baseRect;
    [SerializeField] TextMeshProUGUI magnified;
    private Slider magnifierSlider;

    private void Awake()
    {
        magnifierSlider = GetComponent<Slider>();
    }
    void Start()
    {
        AddSliderEvent();
    }

    private void AddSliderEvent()
    {
        magnifierSlider.onValueChanged.AddListener(ValueChanged) ;
    }

    private void ValueChanged(float value)
    {
        baseRect.content.localScale = new Vector3(value, value, 1);
        magnified.text = string.Format("Zoom: {0:0.00}x", value);
    }
}
