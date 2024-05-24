using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    GameObject player;
    GameObject item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HpItem"))
        {
            Debug.Log("�÷��̾� ü�� ������ �浹");
            player = GameObject.Find("Player");
            player.GetComponent<Main_PMove>().hp += other.GetComponent<ItemStatus>().healValue;
            
            other.gameObject.SetActive(false);
        }

    }
    
}
