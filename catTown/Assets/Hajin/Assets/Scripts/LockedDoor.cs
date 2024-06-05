using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool is_havingKey = false;
    bool is_PlayerEnter = false;
    bool is_Open = false;
    public GameObject player;
    public GameObject key;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(key != null)
        {
            is_havingKey = key.GetComponent<KeyScrip>().is_havingKey;
        }

        playAnimation();
    }
    
    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == player)
        {            
            is_PlayerEnter = true;            
        }
        Debug.Log(is_PlayerEnter);
        Debug.Log("is_havingKey");
    }

    void playAnimation()
    {
        if (is_PlayerEnter && Input.GetKeyUp(KeyCode.F))
        { 
            if (is_havingKey)
            {
                Debug.Log("open");
                anim.SetTrigger("Open");
                is_Open = true; 
            }           
            
        }


    }
}
