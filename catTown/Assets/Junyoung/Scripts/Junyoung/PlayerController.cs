using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Main_PMove main_PMove;
    private Transform playertransform;
    private Rigidbody rigidbody;
    [SerializeField] Transform playerRespawn;


    private void Awake()
    {
        // Player ��ũ��Ʈ�� ���� GameObject���� ã���ϴ�
        main_PMove = GetComponent<Main_PMove>();
        playertransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Player ��ũ��Ʈ�� ����� �����Ǿ����� Ȯ���մϴ�
        if (main_PMove == null)
        {
            Debug.LogError("Player ��ũ��Ʈ�� ã�� �� �����ϴ�!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (main_PMove != null)
        {
            main_PMove.hp -= damage;
            if (main_PMove.hp <= 0)
            {
                // ����
            }
        }
    }

    public void Respawn()
    {
        playertransform.position = playerRespawn.position;
        rigidbody.position = playerRespawn.position;
        rigidbody.velocity = Vector3.zero;
        Debug.Log("������");
        
        if (main_PMove != null)
        {
            main_PMove.hp = 10;  // ü���� �ִ�ġ�� ȸ��
            
        }
    }
}
