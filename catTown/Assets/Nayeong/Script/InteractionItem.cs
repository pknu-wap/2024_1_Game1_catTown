using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    GameObject player;

    private int healValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HpItem"))
        {
            player = GameObject.Find("Player");

            healValue = other.GetComponent<ItemStatus>().healValue;
            if (healValue > 0)
            {
                Debug.Log(healValue+"��ŭ ȸ��");
            }
            else
            {
                Debug.Log(healValue+"��ŭ ����");
            }

            player.GetComponent<Main_PMove>().hp += other.GetComponent<ItemStatus>().healValue;
            
            other.gameObject.SetActive(false);
        }

    }
    
}