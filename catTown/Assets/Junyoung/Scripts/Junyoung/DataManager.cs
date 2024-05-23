using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// �����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� ���̽����� ��ȯ
// 3. ���̽��� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ���������·� ��ȯ
// 3. �ҷ��� �����͸� ���

public class SaveData
{
    public bool constructionSave = false;
    public bool apartSave = false;
}

public class DataManager : MonoBehaviour
{
    // �̱���
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

        // ������ ���
        path = Application.persistentDataPath + "/";
        Debug.Log(path);
    }
    
    void Start()
    {
        
    }

    // ���̺� ���� ������ SaveData() ���� �ϵ��� �ϱ�
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
