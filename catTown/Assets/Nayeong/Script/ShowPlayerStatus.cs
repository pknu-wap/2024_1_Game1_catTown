using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� ���� HP ȸ�� �� ���� �׽�Ʈ�� ��ũ��Ʈ
/// </summary>
public class ShowPlayerStatus : MonoBehaviour
{
    GameObject player;
    public float interval = 2f;

    void Start()
    {
        StartCoroutine(DebugHPRoutine());
    }

    IEnumerator DebugHPRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            player = GameObject.Find("Player");
            Debug.Log("Player HP : " + player.GetComponent<Main_PMove>().hp);
            Debug.Log("Player CT : " + player.GetComponent<Main_PMove>().ct);
        }
    }
}