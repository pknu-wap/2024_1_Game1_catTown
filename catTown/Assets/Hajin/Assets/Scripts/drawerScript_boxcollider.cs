using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerScript_boxcollider : MonoBehaviour
{
    public GameObject ob;
    bool is_DrawerOpen;

    void Awake()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        is_DrawerOpen = ob.GetComponent<drawerScript>().is_DrawerOpen;
    }

    void is_nextPossible ()
    {
        if (is_DrawerOpen == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        is_nextPossible();
    }
}
