using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartSavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // constructionSave를 true로 설정
            DataManager.instance.saveData.apartSave = true;
            // 데이터 저장
            DataManager.instance.SaveData();
            Debug.Log("아파트 세이브 포인트가 설정 되었습니다");
        }
    }
}
