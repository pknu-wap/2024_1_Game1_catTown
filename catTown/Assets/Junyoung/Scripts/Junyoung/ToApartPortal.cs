using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToApartPortal : MonoBehaviour
{
    // �÷��̾���� �浹�� �����ϴ� �Լ�
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Change Scene");

        // �÷��̾ ���� ���� �ִ��� Ȯ���ϰ� F Ű�� �������� Ȯ��

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {

            // ���� ������ �̵�
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
