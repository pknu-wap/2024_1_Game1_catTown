using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollidedPlane : MonoBehaviour
{
    [SerializeField]
    private int cautionAmount = 5;

    private bool isCollidedPlane = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isCollidedPlane = true;

            InteractionUI.Instance.GiveCaution(cautionAmount);
        }
    }
}
