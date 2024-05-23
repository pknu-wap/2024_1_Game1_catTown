using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealItem"))
        {
            Debug.Log("플레이어와 회복 아이템 충돌");
            Destroy(other);
            GameItemManager.Instance.IncreasePlayerHealth();

        }
    }
}
