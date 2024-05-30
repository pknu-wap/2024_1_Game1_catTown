using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
    public GameObject scene2Button;
    public GameObject scene3Button;
    public void StartGame()
    {
        SceneManager.LoadScene("test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene2()
    {
        if(DataManager.instance.saveData.constructionSave == true)
        {
            scene2Button.SetActive(true);
            StartScene2();
        }
        Debug.Log("���� Scene1�� Ŭ�������� ���Ͽ����ϴ�.");
        Debug.Log(DataManager.instance.saveData.constructionSave);
    }
    public void LoadScene3()
    {
        if (DataManager.instance.saveData.apartSave == true)
        {
            scene3Button.SetActive(true);
            StartScene3();
        }
        Debug.Log("���� Scene2�� Ŭ�������� ���Ͽ����ϴ�.");
        Debug.Log(DataManager.instance.saveData.apartSave);
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
}
