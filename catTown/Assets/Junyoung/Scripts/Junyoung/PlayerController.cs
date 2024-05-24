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
        // Player 스크립트를 같은 GameObject에서 찾습니다
        main_PMove = GetComponent<Main_PMove>();
        playertransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Player 스크립트가 제대로 참조되었는지 확인합니다
        if (main_PMove == null)
        {
            Debug.LogError("Player 스크립트를 찾을 수 없습니다!");
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
                // 죽음
            }
        }
    }

    public void Respawn()
    {
        playertransform.position = playerRespawn.position;
        rigidbody.position = playerRespawn.position;
        rigidbody.velocity = Vector3.zero;
        Debug.Log("리스폰");
        
        if (main_PMove != null)
        {
            main_PMove.hp = 10;  // 체력을 최대치로 회복
            
        }
    }
}
