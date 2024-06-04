using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템으로 인한 HP 회복 및 감소 테스트용 스크립트
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