using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM3Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // backgroundMusic2�� ��� ���� ����
            if (AudioManager.instance != null && AudioManager.instance.backgroundMusic3 != null)
            {
                AudioManager.instance.ChangeBackgroundMusic(AudioManager.instance.backgroundMusic3);
            }
            else
            {
                Debug.LogWarning("AudioManager instance or backgroundMusic3 is not assigned.");
            }
        }
    }
}
