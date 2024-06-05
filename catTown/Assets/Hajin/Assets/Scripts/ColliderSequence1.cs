using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ColliderSequence1 : MonoBehaviour
{
    public GameObject activatingObject; 
    public GameObject previousObject;
    public bool is_nextPossible;
    
    private void Start() 
    {
        
    }
    private void Update()
    {
        is_nextPossible = previousObject.GetComponent<drawerScript>().is_nextPossible;
        is_PreviousObjectActivated();

        
    }
    

    void is_PreviousObjectActivated()
    {
        if (is_nextPossible)
        {
            activatingObject.SetActive(false);
        }
    }
}