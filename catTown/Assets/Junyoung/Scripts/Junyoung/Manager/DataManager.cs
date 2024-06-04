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
        // �ν��Ͻ��� �������� ������ ���� �ν��Ͻ��� �Ҵ��ϰ�, �׷��� ������ �ν��Ͻ��� �ı�
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

        // ������ ���
        path = Application.persistentDataPath + "/";
        Debug.Log(path);

        // ������ �ε�
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

            // constructionSave�� apartSave�� true�̸� ��ư Ȱ��ȭ
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
            Debug.Log("���̺� ������ �����ϴ�.");
        }
    }

    public void ResetData() 
    {
        saveData.constructionSave = false;
        saveData.apartSave = false;
        SaveData();
        // Canvas ������Ʈ�� ã���ϴ�.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas�� �ڽ��� Image ������Ʈ�� ã���ϴ�.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image�� �ڽ��� Scene2Button ������Ʈ�� ã���ϴ�.
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
        // Canvas ������Ʈ�� ã���ϴ�.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas�� �ڽ��� Image ������Ʈ�� ã���ϴ�.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image�� �ڽ��� Scene2Button ������Ʈ�� ã���ϴ�.
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
        // Canvas ������Ʈ�� ã���ϴ�.
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            // Canvas�� �ڽ��� Image ������Ʈ�� ã���ϴ�.
            Transform imageTransform = canvas.transform.Find("Image");
            if (imageTransform != null)
            {
                // Image�� �ڽ��� Scene3Button ������Ʈ�� ã���ϴ�.
                Transform scene3ButtonTransform = imageTransform.Find("Scene3Button");
                if (scene3ButtonTransform != null)
                {
                    scene3ButtonTransform.gameObject.SetActive(true);
                }
            }
        }
    }
}
