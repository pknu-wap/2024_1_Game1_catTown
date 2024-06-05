using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageSequenceManager : MonoBehaviour
{
    public Image[] images; // 7개의 이미지를 할당할 배열
    public float displayTime = 5f; // 각 이미지를 표시할 시간 (초)
    public string nextSceneName; // 다음 씬 이름

    private void Start()
    {
        StartCoroutine(DisplayImages());
    }

    private IEnumerator DisplayImages()
    {
        for (int i = 0; i < images.Length; i++)
        {
            // 모든 이미지를 비활성화
            foreach (Image img in images)
            {
                img.gameObject.SetActive(false);
            }

            // 현재 이미지를 활성화
            images[i].gameObject.SetActive(true);

            // displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);
        }

        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
}
