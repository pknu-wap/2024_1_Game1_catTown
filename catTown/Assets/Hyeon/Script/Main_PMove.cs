using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main_PMove : MonoBehaviour
{
    void CallNextScene ()
    {
        SceneManager.LoadScene("test", LoadSceneMode.Additive); //미로
        SceneManager.LoadScene("ApartmentScene",  LoadSceneMode.Additive);//아파트
        SceneManager.LoadScene("constructionSite",  LoadSceneMode.Additive);//공사장
    }
 

    // 플레이어 이동 속도
    private float walkSpeed= 3f;
    
    private float runSpeed = 6f;

    public bool isRunnig = false;
    public bool isStaminaHeal = true; //불 함수를 통한 스태미너 힐 처리 
    public bool isCaution = true;

    public float applySpeed;

    //캐릭터 컨트롤러 변수
    CharacterController cc;

    //플레이어 체력 변수

    public int hp = 10; //hp = health point

    public int maxHp = 10;
    public int minHp = 0;

    public int hpd = 2;
    public int hph = 5;

    public Slider hpSlider; //ui 머리 위로 감춰둠.

    //플레이어 스태미나 변수
    private int st = 1000;
    float staminaHealthTime = 0.0f; //스태미너 힐 딜레이를 위한 타임 기본 값

    private int maxSt = 1000;
    private int minSt = -5;

    private int std = 10; // stemina damega
    private int sth = 5; // stemina heal

    public Slider stSlider;

    //위험도 변수 제어
    
    private int ct = 0; //ct = caution
    float cautionHealthTime = 0.0f;

    private int maxCt = 50;
    private int minCt = 0;

    private int ctd = 10;
    private int cth = 5;

    public Slider ctSlider;

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

        LoadData();

    }

    void LoadData() //플레이어 데이터 씬 이동 시 이전 코드
    {


    }

    void Update(){
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //플레이어 이동 방향
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //Shift 키 입력에 따른 달리기 제어 조건문 및 스태미너 감소 제어

    if (Input.GetMouseButton(0) && st > 0 && dir != Vector3.zero) 
        //점프랑 동일한 구조 함수, 달리기 확인에 필요한 dir값의 좌표 이동에 따른 값 변동의 
        {
           //Debug.Log("나는 달릴거야"); //콘솔 내 실행 디버그
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

    // 씬 전환 조건문

    if(Input.GetKeyDown(KeyCode.P)){
        SceneManager.LoadScene("ApartmentScene");
    }
    if(Input.GetKeyDown(KeyCode.O)){
            SceneManager.LoadScene("constructionSite");
    }
    if(Input.GetKeyDown(KeyCode.I)){
        SceneManager.LoadScene("test");
    }
    
    Monster Shadowlop = GameObject.GetComponent<Monster>();
    Debug.Log(isHitting);

    if(isHitting == true)
    {
        hp -= hpd;
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
        if(st < 0) st = 0;
    }

    if(isStaminaHeal) //스태미나 힐 작동 조건문 
    {
        st += sth;
        if(st > 1000) st = 1000;
    }

    //위험도 값 변환

    if(isCaution == false)
    {
        cautionHealthTime += Time.deltaTime;
        if(cautionHealthTime > 5.0f)
        {
            cautionHealthTime = 5.0f;
            isCaution = true;
        }
    }

    if(isCaution)
    {
        ct += cth;
        if(ct < 0) ct = 0;
    }
    //현재 플레이어 체력 퍼센테이지를 체력바의 Value에 반영

    hpSlider.value = (float)hp / (float)maxHp;

    stSlider.value = (float)st / (float)maxSt;

    ctSlider.value = (float)ct / (float)minCt;

}
}