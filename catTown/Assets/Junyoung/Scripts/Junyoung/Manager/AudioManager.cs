using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // 싱글톤 인스턴스

    public AudioClip backgroundMusic1;
    public  AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 오디오 매니저가 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
            return; // 기존 인스턴스가 존재하면 초기화를 중지합니다.
        }
    }

    void Start()
    {
        // AudioSource 컴포넌트를 가져오거나 없으면 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 배경 음악 설정
        if (backgroundMusic1 != null)
        {
            audioSource.clip = backgroundMusic1;

            // 반복 재생 설정
            audioSource.loop = true;

            // 배경 음악 재생
            PlayBackgroundMusic();
        }
        else
        {
            Debug.LogWarning("Background music 1 is not assigned.");
        }
    }

    // 배경 음악을 재생하는 함수
    public void PlayBackgroundMusic()
    {
        // 오디오 재생
        audioSource.Play();
    }

    // 배경 음악을 변경하고 재생하는 함수
    public void ChangeBackgroundMusic(AudioClip newClip)
    {
        if (newClip != null)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("New background music clip is not assigned.");
        }
    }
}
