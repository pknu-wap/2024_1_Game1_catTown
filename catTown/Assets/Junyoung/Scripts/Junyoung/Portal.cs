using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // �÷��̾���� �浹�� �����ϴ� �Լ�
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Change Scene");

        // �÷��̾ ���� ���� �ִ��� Ȯ���ϰ� E Ű�� �������� Ȯ��
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
            // ���� ������ �̵�
            SceneManager.LoadScene("constructionSite");
            
        }
    }
}
