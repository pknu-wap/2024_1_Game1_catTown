using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructSavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // constructionSave�� true�� ����
            DataManager.instance.saveData.constructionSave = true;
            // ������ ����
            DataManager.instance.SaveData();
            Debug.Log("������ ���̺� ����Ʈ�� ���� �Ǿ����ϴ�");
        }
    }
}
