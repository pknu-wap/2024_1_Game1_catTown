using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartSavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // constructionSave�� true�� ����
            DataManager.instance.saveData.apartSave = true;
            // ������ ����
            DataManager.instance.SaveData();
            Debug.Log("����Ʈ ���̺� ����Ʈ�� ���� �Ǿ����ϴ�");
        }
    }
}
