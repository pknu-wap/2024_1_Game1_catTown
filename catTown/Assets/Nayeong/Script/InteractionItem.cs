using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    GameObject player;

    private void Awake() // already find player
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {   
        // increased & decreased HP
        if (other.CompareTag("HpItem"))
        {
            // player = GameObject.Find("Player");

            var healValue = other.GetComponent<ItemStatus>().HealAmount;
            if (healValue > 0)
            {
                Debug.Log(healValue + " increased");
            }
            else
            {
                Debug.Log(-healValue + " decreased");
            }

            player.GetComponent<Main_PMove>().hp += other.GetComponent<ItemStatus>().HealAmount;

            other.gameObject.SetActive(false);
        }

        // increased Caution Rate
        /*if (other.CompareTag("CautionObject"))
        {
            var cautionValue = other.GetComponent<CautionStatus>().CautionAmount;
        }*/

    }

}