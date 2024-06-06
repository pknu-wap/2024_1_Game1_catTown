using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScrip : MonoBehaviour
{
    public bool is_havingKey = false;
    public bool is_PlayerEnter  = false;
    public GameObject Key;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pickupKey();
        
    }



    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == player)
        {            
            is_PlayerEnter = true;            
        }
        Debug.Log(is_PlayerEnter);


    }

    void pickupKey()
    {
        if (is_PlayerEnter && Input.GetKeyUp(KeyCode.F))
        {            
            Debug.Log("Picked up a key");
            is_havingKey = true;
            Key.SetActive(false);

        }


    }
}
