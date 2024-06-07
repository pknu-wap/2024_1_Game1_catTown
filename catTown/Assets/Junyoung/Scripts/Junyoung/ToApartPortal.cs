using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToApartPortal : MonoBehaviour
{
    // 플레이어와의 충돌을 감지하는 함수
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Change Scene");

        // 플레이어가 포털 위에 있는지 확인하고 F 키를 눌렀는지 확인

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {

            // 다음 씬으로 이동
            SceneManager.LoadScene("ApartmentScene");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionUI.Instance.textAppear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionUI.Instance.textDisappear();
        }
    }
}
