using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInertia : MonoBehaviour
{
    public float deceleration = 0.1f; // 감속(관성)
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity -= rb.velocity.normalized * deceleration * Time.deltaTime;

            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
