using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerScript_boxcollider : MonoBehaviour
{
    public GameObject ob;
    bool is_nextPossible;

    void Awake()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        is_nextPossible = ob.GetComponent<drawerScript>().is_nextPossible;
    }

    void is_NextPossible ()
    {
        if (is_nextPossible == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        is_NextPossible();
    }
}
