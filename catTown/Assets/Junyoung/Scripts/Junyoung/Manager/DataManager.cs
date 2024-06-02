using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 저장하는 방법
// 1. 저장할 데이터가 존재
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터형태로 변환
// 3. 불러온 데이터를 사용

public class SaveData
{
    public bool constructionSave = false;
    public bool apartSave = false;
}

public class DataManager : MonoBehaviour
{
    // 싱글톤
    public static DataManager instance;

    public SaveData saveData = new SaveData();

    string path;
    string filename = "save";

    private void Awake()
    {
        // 인스턴스가 존재하지 않으면 현재 인스턴스를 할당하고, 그렇지 않으면 인스턴스를 파괴
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // 저장할 경로
        path = Application.persistentDataPath + "/";
        Debug.Log(path);

        // 데이터 로드
        LoadData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);

    }

    public void LoadData()
    {
        if (File.Exists(path + filename))
        {
            string data = File.ReadAllText(path + filename);
            saveData = JsonUtility.FromJson<SaveData>(data);

            // constructionSave나 apartSave가 true이면 버튼 활성화
            if (saveData.constructionSave)
            {
                ActiveConstructButton();
            }
            if (saveData.apartSave)
            {
                ActiveApartButton();
            }
        }
        else
        {
            Debug.Log("세이브 파일이 없습니다.");
        }
    }

    public void ResetData() 
    {
        saveData.constructionSave = false;
        saveData.apartSave = false;
        SaveData();
        // Canvas 오브젝트를 찾습니다.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas의 자식인 Image 오브젝트를 찾습니다.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image의 자식인 Scene2Button 오브젝트를 찾습니다.
                Transform scene2ButtonTransform = imageTransform.Find("Scene2Button");
                Transform scene3ButtonTransform = imageTransform.Find("Scene3Button");
                if (scene2ButtonTransform != null && scene3ButtonTransform != null)
                {
                    scene2ButtonTransform.gameObject.SetActive(false);
                    scene3ButtonTransform.gameObject.SetActive(false);
                    
                }
            }
        }
    }

    public void ActiveConstructButton()
    {
        // Canvas 오브젝트를 찾습니다.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas의 자식인 Image 오브젝트를 찾습니다.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image의 자식인 Scene2Button 오브젝트를 찾습니다.
                Transform scene2ButtonTransform = imageTransform.Find("Scene2Button");
                if (scene2ButtonTransform != null)
                {
                    scene2ButtonTransform.gameObject.SetActive(true);
                }
            }
        }
    }

    public void ActiveApartButton()
    {
        // Canvas 오브젝트를 찾습니다.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas의 자식인 Image 오브젝트를 찾습니다.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image의 자식인 Scene3Button 오브젝트를 찾습니다.
                Transform scene3ButtonTransform = imageTransform.Find("Scene3Button");
                if (scene3ButtonTransform != null)
                {
                    scene3ButtonTransform.gameObject.SetActive(true);
                }
            }
        }
    }
}
