using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // 플레이어와의 충돌을 감지하는 함수
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Change Scene");

        // 플레이어가 포털 위에 있는지 확인하고 E 키를 눌렀는지 확인
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
            // 다음 씬으로 이동
            SceneManager.LoadScene("constructionSite");
            
        }
    }
}
