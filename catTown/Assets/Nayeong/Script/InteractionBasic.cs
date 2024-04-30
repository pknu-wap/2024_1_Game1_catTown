using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionBasic : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Warning Object"))
        {
            Debug.Log("hello");
        }
    }

    public void IncreaseWarningCnt(int cnt)
    {
        WarningCnt += cnt;
    }

}
