using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetScript : MonoBehaviour
{
    Animator anim;
    bool is_PlayerEnter; 
    public GameObject player;

    private void Awake()
    {

        anim = GetComponent<Animator>();

        is_PlayerEnter = false;
    }
   
	void Update ()
    {
        playDrawerAnimation();
		
	}
    // 콜라이더를 가진 객체가 (트리거옵션이 체크된)콜라이더 범위 안으로 들어왔고 그게 플레이어라면 
    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == player)
        {            
            is_PlayerEnter = true;            
        }
        Debug.Log(is_PlayerEnter);
    }
    // 콜라이더를 가진 객체가 콜라이더 범위 밖으로 나갔고 그 객체가 플레이어라면
    void OnTriggerExit(Collider other)
    {       
        if (other.gameObject == player)
        {
            is_PlayerEnter = false;
        }
        Debug.Log(is_PlayerEnter);
    }

    void playDrawerAnimation()
    {
        if (is_PlayerEnter && Input.GetKeyUp(KeyCode.E))
        {            
            Debug.Log("open");
            anim.SetTrigger("Open");

        }


    }
}
