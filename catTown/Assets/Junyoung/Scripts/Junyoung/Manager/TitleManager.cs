using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject existingCanvas; // 기존 캔버스
    public Image[] images; // 7개의 이미지 배열
    public float displayTime = 4f; // 각 이미지를 표시할 시간 (초)

    public GameObject scene2Button;
    public GameObject scene3Button;

    private void Start()
    {

    }

    public void StartGame()
    {
        StartCoroutine(DisplayImages());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene2()
    {
        if (DataManager.instance.saveData.constructionSave == true)
        {
            scene2Button.SetActive(true);
            StartScene2();
        }
    }

    public void LoadScene3()
    {
        if (DataManager.instance.saveData.apartSave == true)
        {
            scene3Button.SetActive(true);
            StartScene3();
        }
    }

    public void Reset()
    {
        DataManager.instance.ResetData();
    }

    private void StartScene2()
    {
        SceneManager.LoadScene("constructionSite");
    }

    private void StartScene3()
    {
        SceneManager.LoadScene("ApartmentScene");
    }

    private IEnumerator DisplayImages()
    {

        for (int i = 0; i < images.Length; i++)
        {
            // 현재 이미지를 활성화
            images[i].gameObject.SetActive(true);

            // displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);

            // 현재 이미지를 비활성화
            //images[i].gameObject.SetActive(false);
        }

        // 다음 씬으로 전환
        SceneManager.LoadScene("test");
    }
}
