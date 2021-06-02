using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicManager : MonoBehaviour
{
    [Header("Reference")] 
    [SerializeField] GameUtility events;
    [SerializeField] PeriodicUIManager PeriodicUIManager;

    private void Awake()
    {
        PeriodicUIManager = GetComponent<PeriodicUIManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonCloseCard()
    {
        events.UpdateContextUI?.Invoke(false);
    }
}
