using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM2Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // backgroundMusic2로 배경 음악 변경
            if (AudioManager.instance != null && AudioManager.instance.backgroundMusic2 != null)
            {
                AudioManager.instance.ChangeBackgroundMusic(AudioManager.instance.backgroundMusic2);
            }
            else
            {
                Debug.LogWarning("AudioManager instance or backgroundMusic2 is not assigned.");
            }
        }
    }
}
