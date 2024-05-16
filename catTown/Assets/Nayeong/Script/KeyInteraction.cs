using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInteractions : MonoBehaviour
{
    public float pickupDistance = 3.0f;
    public Text addKeyText;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (addKeyText != null)
        {
            addKeyText.text = "";
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= pickupDistance)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PickupKey();
            }
        }
    }

    void PickupKey()
    {
        if (addKeyText != null)
        {
            addKeyText.text = "���踦 ȹ���Ͽ����ϴ�!";
        }

        Destroy(gameObject); // ���� ������Ʈ ����
    }
}