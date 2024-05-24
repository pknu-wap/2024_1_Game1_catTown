using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStatus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("충돌");
            InteractionText.Instance.textAppear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player이면
        if (other.gameObject.tag == "Player")
        {
            InteractionText.Instance.textDisappear();
        }
    }
}
