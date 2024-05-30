using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class CautionStatus : MonoBehaviour
{
    [SerializeField] private int cautionAmount;
    public int CautionAmount => cautionAmount;

    private bool isCollidedWithPlayer = false;

    private Transform breakableObject = null;
    private Transform cautionObject = null;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            isCollidedWithPlayer = true;

        }
    }

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "breakable")
            {
                breakableObject = transform.GetChild(i);
            }
            else
            {
                cautionObject = transform.GetChild(i);
            }
        }

    }
 
}

