using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM3Trigger : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        // AudioManager 인스턴스를 찾습니다.
        audioManager = FindObjectOfType<AudioManager>();

        // AudioManager를 찾지 못한 경우 경고 메시지 출력
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioManager != null && audioManager.backgroundMusic3 != null)
            {
                audioManager.ChangeBackgroundMusic(audioManager.backgroundMusic3);
            }
            else
            {
                Debug.LogWarning("AudioManager instance or backgroundMusic3 is not assigned.");
            }
        }
    }
}
