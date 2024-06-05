using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpeedUP : MonoBehaviour
{
    public Monster monster; // ���� ��ü�� �ν����Ϳ��� �Ҵ�

    // Ʈ���Ű� �۵��� �� Monster ��ü�� ã�Ƽ� speedUp�� true�� ����
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
