using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // 플레이어의 체력 변수
    private float playerHealth = 100f;

    // GameManager 인스턴스 생성 및 유일성 보장
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreasePlayerHealth() // 플레이어 체력 회복
    {
        playerHealth += 20f;
        Debug.Log("Player health increased! Current health: " + playerHealth);

    }

    public void DecreasePlayerHealth(float damageAmount) // 플레이어 체력 감소
    {
        playerHealth -= damageAmount;
        Debug.Log("Player health decreased! Current health: " + playerHealth);

    }
}
