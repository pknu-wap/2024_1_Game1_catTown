using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructSavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // constructionSave를 true로 설정
            DataManager.instance.saveData.constructionSave = true;
            // 데이터 저장
            DataManager.instance.SaveData();
            Debug.Log("공사장 세이브 포인트가 설정 되었습니다");
        }
    }
}
