using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool is_havingKey = false;
    bool is_PlayerEnter = false;
    bool is_Open = false;
    public GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playAnimation();
    }
    
    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == player)
        {            
            is_PlayerEnter = true;            
        }
        Debug.Log(is_PlayerEnter);
    }

        void playAnimation()
    {
        if (is_PlayerEnter && Input.GetKeyUp(KeyCode.E) && is_havingKey)
        {            
            Debug.Log("open");
            anim.SetTrigger("Open");
            is_Open = true;
        }


    }
}
