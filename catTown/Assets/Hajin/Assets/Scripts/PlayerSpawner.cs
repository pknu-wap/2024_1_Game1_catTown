using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // 플레이어 프리팹을 연결할 변수
    public Transform spawnTransform; // 플레이어를 스폰할 위치를 가진 오브젝트의 Transform

    public GameObject SpawnPlayer()
    {
        if (spawnTransform != null)
        {
            Debug.Log("일단 통과");
            // 플레이어를 스폰하고 생성된 오브젝트를 반환
            return Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
        }
        return null;
    }

    public void Awake()
    {
        SpawnPlayer();
    }
}
