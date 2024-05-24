using System.Security.Cryptography;
using UnityEngine;

public class CautionStatus : MonoBehaviour
{
    [SerializeField] private int cautionAmount;
    public int CautionAmount => cautionAmount;

    GameObject entity;

    private void OnTriggerEnter(Collider other)
    {   
        // 충돌 방향을 받아서 그 해당 방향으로 날아간다.
        
        // 깨진 조각에 닿이면 위험지수가 오른다.

        // 충돌한게 깨질 때, 위험지수가 오른다.

    }
}
