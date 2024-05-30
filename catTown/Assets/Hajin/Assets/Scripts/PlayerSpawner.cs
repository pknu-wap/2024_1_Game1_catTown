using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // 플레이어 프리팹을 연결할 변수
    public Transform spawnTransform; // 플레이어를 스폰할 위치를 가진 오브젝트의 Transform

    void Awake()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (spawnTransform != null)
        {
            // 플레이어를 스폰
            Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
        }

    }
}


