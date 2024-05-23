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
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this) 
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // 저장할 경로
        path = Application.persistentDataPath + "/";
        Debug.Log(path);
    }
    
    void Start()
    {
        
    }

    // 세이브 지점 찍으면 SaveData() 실행 하도록 하기
    public void SaveData()
    {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        saveData = JsonUtility.FromJson<SaveData>(data);
    }
}
