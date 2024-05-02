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
    public bool isStaminaHeal = true; //코루틴 딜레이에서 불 함수를 통한 스태미너 힐 처리 

    public float applySpeed;

    //캐릭터 컨트롤러 변수
    CharacterController cc;

    //플레이어 체력 변수

    private int hp = 200; //hp = health point

    private int maxHp = 200;
    private int minHp = 0;

    public Slider hpSlider; //ui 머리 위로 감춰둠.

    //플레이어 스태미나 변수

    private int st = 1000; //st = stemina
    float staminaHealthTime = 0.0f; //스태미너 힐 딜레이를 위한 타임 기본 값

    private int maxSt = 1000;
    private int minSt = -5;

    private int std = 10; // stemina damega
    private int sth = 5; // stemina heal

    public Slider stSlider;


    //위험도 변수 제어


    //private int ct = 0; //ct = caution
    

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

        //Shift 키 입력에 따른 달리기 제어 조건문 및 스태미너 감소 제어

    if (Input.GetKey(KeyCode.RightShift) && st > 0 && dir != Vector3.zero) 
        //점프랑 동일한 구조 함수, 달리기 확인에 필요한 dir값의 좌표 이동에 따른 값 변동의 
        {
            Debug.Log("나는 달릴거야"); //콘솔 내 실행 디버그
            isStaminaHeal = false; 
            staminaHealthTime = 0.0f; //스태미나 힐 리셋

            isRunnig = true;
            applySpeed = runSpeed;
            st -= std;

        }
    else{

        isRunnig = false;
        applySpeed = walkSpeed;

    }

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

    
    if(isStaminaHeal == false) //스태미나 힐 작동 조건문 
    {
        staminaHealthTime += Time.deltaTime; // 리얼타임 = 프레임타임 변환 코드
        if(staminaHealthTime > 2.0f)
        {
            staminaHealthTime = 2.0f;
            isStaminaHeal = true;
        }
    }

    if(isStaminaHeal)
    {
        st += sth;
        if(st > 1000) st = 1000;
    }

    //현재 플레이어 체력 퍼센테이지를 체력바의 Value에 반영

    hpSlider.value = (float)hp / (float)maxHp;

    //현재 플레이어 스태미너 퍼센테이즈를 체력바의 Value에 반영

    stSlider.value = (float)st / (float)maxSt;

    }
}

