using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // �÷��̾��� ü�� ����
    private float playerHealth = 100f;

    // GameManager �ν��Ͻ� ���� �� ���ϼ� ����
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

    public void IncreasePlayerHealth() // �÷��̾� ü�� ȸ��
    {
        playerHealth += 20f;
        Debug.Log("Player health increased! Current health: " + playerHealth);

    }

    public void DecreasePlayerHealth(float damageAmount) // �÷��̾� ü�� ����
    {
        playerHealth -= damageAmount;
        Debug.Log("Player health decreased! Current health: " + playerHealth);

    }
}
