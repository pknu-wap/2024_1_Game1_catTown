using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb.useGravity = false; // 시작할 때 중력 비활성화
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            rb.useGravity = true;
        }
    }
}