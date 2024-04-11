using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;
    private bool is_Open = false;

    private void OpenDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Open");
        is_Open = true;
        Debug.Log("true");
    }

    private void CloseDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Close");
        is_Open = false;
        Debug.Log("false");
    }


    void Update()
    {
        if ( is_Open && Input.GetKeyDown(KeyCode.Space))
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ( !is_Open && Input.GetKeyDown(KeyCode.Space))
            {
                OpenDoor();
            }
        }
    }
}
