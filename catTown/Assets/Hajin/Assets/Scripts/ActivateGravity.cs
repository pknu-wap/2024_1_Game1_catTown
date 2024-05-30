using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // 시작할 때 중력 비활성화
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "Player"인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.useGravity = true; // 중력 활성화
        }
    }
}