using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main_PMove : MonoBehaviour
{
    // 플레이어 이동 속도
    private float walkSpeed= 3f;
    
    private float runSpeed = 6f;
    public bool isRunnig = false;

    public float applySpeed;

    //캐릭터 컨트롤러 변수
    CharacterController cc;

    //플레이어 체력 변수

    int hp = 200; //hp = health point

    public int maxHp = 200;
    private int minHp = 0;

    public Slider hpSlider;

    //플레이어 스태미나 변수

    int st = 1000; //st = stemina

    public int maxSt = 1000;
    private int minSt = -5;

    private int std = 10; // stemina damega
    private int sth = 500; // stemina heal

    public Slider stSlider;

    //딜레이 코루틴
    IEnumerator DelayDamst()
        {
            
        float seconds = 10.0f;
        yield return new WaitForSecondsRealtime(seconds);

        }
        IEnumerator DelayHilst()
        {

            float secondsH = 3.0f;
            yield return new WaitForSecondsRealtime(secondsH);
            st += sth;

        }

    //public Animator anim; // 넣을수도 있고 아닐 수도 있는 애니메이션 모션

    //중력, 수직 속도 변수
    float gravity = -20f;

    float yVelocity = 0;
    
    // 점프 제어
    public float jumpPower = 5f;
    public bool isJumping = false;

    // 스크립트 기준 호출
    private void Start()
    {
        //캐릭터 컨트롤러 컴포넌트 받아오기
        cc = GetComponent<CharacterController>();

        //속도 초기화
        applySpeed = walkSpeed;

    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //플레이어 이동 방향
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        transform.position += dir * applySpeed * Time.deltaTime;

        //메인 카메라 시점 기준 이동
        dir = Camera.main.transform.TransformDirection(dir);

        //수직 속도 * 중력 
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * applySpeed * Time.deltaTime);
        

    //스페이스바 입력에 따른 점프 제어 조건문

    if (isJumping && cc.collisionFlags == CollisionFlags.Below)
    {

        isJumping = false;
        yVelocity = 0;

    }

    if (Input.GetButtonDown("Jump") && !isJumping)
    {

        yVelocity = jumpPower;
        isJumping = true;

    }
    
    //Shift 키 입력에 따른 달리기 제어 조건문 및 스태미너 감소 제어

    if (Input.GetKey(KeyCode.RightShift) && st > 0 )
        {
            
            isRunnig = true;
            applySpeed = runSpeed;
            st -= std;

        }
    else{

        isRunnig = false;
        applySpeed = walkSpeed;

        StartCoroutine("DelayDamst");
        StartCoroutine("DelayHilst");

    }

    //현재 플레이어 체력 퍼센테이지를 체력바의 Value에 반영

    hpSlider.value = (float)hp / (float)maxHp;

    //현재 플레이어 스태미너 퍼센테이즈를 체력바의 Value에 반영

    stSlider.value = (float)st / (float)maxSt;

    }
}

