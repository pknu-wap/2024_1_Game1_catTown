using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MatScript : MonoBehaviour
{
    public GameObject activatingObject; 
    public GameObject BlockingObject;
    public bool is_keyPossible = false;
    public bool is_nextPossible;
    
    private void Start() 
    {
        
    }
    private void Update()
    {
        is_nextPossible = BlockingObject.activeSelf;
        is_PreviousObjectActivated();

        
    }
    

    void is_PreviousObjectActivated()
    {
        if (is_nextPossible == false)
        {
            activatingObject.SetActive(true);
            is_keyPossible = true;
        }
    }
}