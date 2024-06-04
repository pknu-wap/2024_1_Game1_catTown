using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance; // �̱��� �ν��Ͻ�

    public AudioClip backgroundMusic1;
    public  AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    void Awake()
    {
        //// �̱��� �ν��Ͻ� ����
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����� �Ŵ����� �ı����� �ʵ��� ����
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return; // ���� �ν��Ͻ��� �����ϸ� �ʱ�ȭ�� �����մϴ�.
        //}
    }

    void Start()
    {
        // AudioSource ������Ʈ�� �������ų� ������ �߰��մϴ�.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ��� ���� ����
        if (backgroundMusic1 != null)
        {
            audioSource.clip = backgroundMusic1;

            // �ݺ� ��� ����
            audioSource.loop = true;

            // ��� ���� ���
            PlayBackgroundMusic();
        }
        else
        {
            Debug.LogWarning("Background music 1 is not assigned.");
        }
    }

    // ��� ������ ����ϴ� �Լ�
    public void PlayBackgroundMusic()
    {
        // ����� ���
        audioSource.Play();
    }

    // ��� ������ �����ϰ� ����ϴ� �Լ�
    public void ChangeBackgroundMusic(AudioClip newClip)
    {
        if (newClip != null)
        {
            Debug.Log("complete change BGM");
            audioSource.clip = newClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("New background music clip is not assigned.");
        }
    }
}
