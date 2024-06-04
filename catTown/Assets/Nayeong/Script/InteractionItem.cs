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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Noise");
        if (collision.gameObject.CompareTag("CautionFraction"))
        {
            noiseAmount += 1;

            if (noiseAmount == 1)
            {
                StartCoroutine(OnDecreasedNoise());
            }

            if (noiseAmount > limitNoise)
            {
                player.GetComponent<Main_PMove>().ct += 2;
            }
        }
    }

    public int noiseAmount = 0;
    private int limitNoise = 10;

    IEnumerator OnDecreasedNoise()
    {    
        while (noiseAmount > 0)
        {
            Debug.Log("In Coroutine" + noiseAmount);

            var beforePos = gameObject.transform.position;
            yield return new WaitForSeconds(0.5f);

            if (beforePos == gameObject.transform.position)
            {
                noiseAmount -= 10;
            }

            noiseAmount -= 1;

        }
        noiseAmount = 0;
    }

}