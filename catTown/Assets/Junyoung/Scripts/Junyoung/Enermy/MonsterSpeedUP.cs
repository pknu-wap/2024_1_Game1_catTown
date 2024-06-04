using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpeedUP : MonoBehaviour
{
    public Monster monster; // 몬스터 객체를 인스펙터에서 할당

    // 트리거가 작동할 때 Monster 객체를 찾아서 speedUp을 true로 설정
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monster != null)
            {
                monster.speedUp = true;
                Debug.Log("SpeedUP triggered");
            }
            else
            {
                Debug.Log("Monster reference is not assigned.");
            }
        }
    }
}
