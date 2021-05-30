using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] GameUtility gu;
    void Start()
    {
        Debug.Log(gu.ElementData["Hydrogen"].AtomicMass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
