using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class CautionStatus : MonoBehaviour
{
    [SerializeField] private int cautionAmount;
    public int CautionAmount => cautionAmount;

    private bool isCollidedWithPlayer = false;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            isCollidedWithPlayer = true;
        }


    }
}
