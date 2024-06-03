using UnityEngine;
using System.Collections.Generic;

public class ColliderSequence: MonoBehaviour
{
    public List<GameObject> objectsToCheck; // 활성화 상태를 확인할 오브젝트 리스트
    public List<GameObject> objectsToTrigger; // IsTrigger를 설정할 오브젝트 리스트

    private List<Collider> collidersToTrigger; // IsTrigger를 설정할 콜라이더 리스트

    void Start()
    {
        if (objectsToCheck == null || objectsToTrigger == null)
        {
            Debug.LogError("오브젝트 리스트가 설정되지 않았습니다.");
            return;
        }

        // 콜라이더 리스트 초기화
        collidersToTrigger = new List<Collider>();

        foreach (var obj in objectsToTrigger)
        {
            var col = obj.GetComponent<Collider>();
            if (col != null && col.isTrigger)
            {
                collidersToTrigger.Add(col);
            }
            else if (col == null)
            {
                Debug.LogWarning($"오브젝트 {obj.name}에 콜라이더가 없습니다.");
            }
        }
    }

    void Update()
    {
        bool allActive = true;

        // 모든 오브젝트가 활성화 상태인지 확인
        foreach (var obj in objectsToCheck)
        {
            if (!obj.activeInHierarchy)
            {
                allActive = false;
                break;
            }
        }

        // 콜라이더의 IsTrigger 설정
        foreach (var col in collidersToTrigger)
        {
            col.enabled = allActive;
        }
    }
}