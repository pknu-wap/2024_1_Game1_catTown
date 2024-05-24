using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStatus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("�浹");
            InteractionText.Instance.textAppear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractionText.Instance.textDisappear();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Show Paper Image");

                // ��������Ʈ �̹��� ����.
            }
        }
    }
}
