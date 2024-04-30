using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // 배경 음악
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트를 가져오거나 없으면 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 배경 음악 설정
        audioSource.clip = backgroundMusic;

        // 반복 재생 설정
        audioSource.loop = true;

        // 배경 음악 재생
        PlayBackgroundMusic();
    }

    // 배경 음악을 재생하는 함수
    public void PlayBackgroundMusic()
    {
        // 오디오 재생
        audioSource.Play();
    }

    // 배경 음악을 일시 정지하는 함수
    public void PauseBackgroundMusic()
    {
        // 오디오 일시 정지
        audioSource.Pause();
    }

    // 배경 음악을 다시 재생하는 함수
    public void ResumeBackgroundMusic()
    {
        // 오디오 다시 재생
        audioSource.Play();
    }

    // 배경 음악을 정지하는 함수
    public void StopBackgroundMusic()
    {
        // 오디오 정지
        audioSource.Stop();
    }
}
