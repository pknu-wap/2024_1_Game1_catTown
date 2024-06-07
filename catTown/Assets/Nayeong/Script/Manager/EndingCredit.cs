using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    [SerializeField] private int endNumber = 0;
    public int EndNumber => endNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionUI.Instance.endingAppear(endNumber);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionUI.Instance.endingDisAppear(endNumber);
        }
    }
}
