using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class InteractionBasic : MonoBehaviour
{

    public float warningIndex = 0f;

    public event EventHandler OnCoillsionWarningEvent;

    void Update()
    {
        warningIndex -= Time.deltaTime * 0.1f;
        warningIndex = Mathf.Clamp(warningIndex, 0f, 100f);
    }

    /// <summary>
    /// 위험 지수를 올리는 오브젝트와의 충돌 시 일어나는 함수
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Warning Object"))
        {
            OnCoillsionWarningEvent?.Invoke(this, EventArgs.Empty);

            warningIndex += 0.2f;
            warningIndex = Mathf.Clamp(warningIndex, 0f, 100f);

            Rigidbody rd = collision.gameObject.GetComponent<Rigidbody>();
            if (rd != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                rd.AddForce(pushDirection * 1f, ForceMode.Impulse);
            }
        }
    }

}