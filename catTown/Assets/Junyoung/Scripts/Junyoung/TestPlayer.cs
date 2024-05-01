using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class TestPlayer : MonoBehaviour
{
    void CallNextScene ()
    {
    
        SceneManager.LoadScene("test", LoadSceneMode.Additive); //誘몃
        SceneManager.LoadScene("ApartmentScene",  LoadSceneMode.Additive);//
    }


    // �댁 대 
    private float walkSpeed= 3f;
    
    private float runSpeed = 6f;

    public bool isRunnig = false;
    public bool isStaminaHeal = true; //肄猷⑦ �댁 遺 ⑥瑜 듯 ㅽ誘몃  泥由 
    public bool isCaution = true;

    public float applySpeed;

    //罹由� 而⑦몃· 蹂
    CharacterController cc;

    //�댁 泥대 蹂

    private int hp = 10; //hp = health point

    private int maxHp = 10;
    private int minHp = 0;

    private int hpd = 2;
    private int hph = 5;

    public Slider hpSlider; //ui 癒몃━ 濡 媛異곕.

    //�댁 ㅽ誘몃 蹂
    private int st = 1000;
    float staminaHealthTime = 0.0f; //ㅽ誘몃  �대�   湲곕낯 媛

    private int maxSt = 1000;
    private int minSt = -5;

    private int std = 10; // stemina damega
    private int sth = 5; // stemina heal

    public Slider stSlider;

    // 蹂 �
    
    private int ct = 0; //ct = caution
    float cautionHealthTime = 0.0f;

    private int maxCt = 50;
    private int minCt = 0;

    private int ctd = 10;
    private int cth = 5;

    public Slider ctSlider;

    // 諛 쇨꺽 ui 댄 
    //public attackP hitEffect;

    public void DamegeAction(int damege)
    {
        hp -= hpd;
    }

    //以�, 吏  蹂
    float gravity = -20f;
    float yVelocity = 0;
    
    // � �
    public float jumpPower = 5f;
    public bool isJumping = false;

    // ㅽщ┰ 湲곗 몄
    private void Start()
    {
        
        //罹由� 而⑦몃· 而댄щ 諛ㅺ린
        cc = GetComponent<CharacterController>();

        // 珥湲고
        applySpeed = walkSpeed;

        LoadData();

    }

    void LoadData()
    {


    }

    void Update(){
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //�댁 대 諛⑺
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //Shift  �μ 곕Ⅸ щ━湲 � 議곌굔臾 諛 ㅽ誘몃 媛 �

    if (Input.GetKey(KeyCode.RightShift) && st > 0 && dir != Vector3.zero) 
        //� 쇳 援ъ“ ⑥, щ━湲 몄  dir媛 醫 대 곕Ⅸ 媛 蹂 
        {
           //Debug.Log(" щ┫嫄곗"); //肄  ㅽ 踰洹
            isStaminaHeal = false; 
            staminaHealthTime = 0.0f; //ㅽ誘몃  由ъ


            isRunnig = true;
            applySpeed = runSpeed;
            st -= std;
        }
    else{

        isRunnig = false;
        applySpeed = walkSpeed;

         }

        transform.position += dir * applySpeed * Time.deltaTime;

        //硫 移대 � 湲곗 대
        dir = Camera.main.transform.TransformDirection(dir);

        //吏  * 以� 
=======

public class TestPlayer : MonoBehaviour
{
    // 플레이어 이동 속도
    private float walkSpeed = 3f;

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

        


        //ㅽ댁ㅻ �μ 곕Ⅸ � � 議곌굔臾

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

    //  � 議곌굔臾

    if(Input.GetKeyDown(KeyCode.P)){
        SceneManager.LoadScene("ApartmentScene");
    }
    //if(Input.GetKeyDown(KeyCode.o)){}

    if(Input.GetKeyDown(KeyCode.I)){
        SceneManager.LoadScene("test");
    }

    if(isStaminaHeal == false) //ㅽ誘몃   議곌굔臾 
    {
        staminaHealthTime += Time.deltaTime; // 由ъ쇳 = � 蹂 肄
        if(staminaHealthTime > 2.0f)
        {
            staminaHealthTime = 2.0f;
            isStaminaHeal = true;
        }
    }

    if(isStaminaHeal) //ㅽ誘몃   議곌굔臾 
    {
        st += sth;
        if(st > 1000) st = 1000;
    }

    // 媛 蹂

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
    // �댁 泥대 쇱쇳댁瑜 泥대λ Value 諛

    hpSlider.value = (float)hp / (float)maxHp;

    stSlider.value = (float)st / (float)maxSt;

    ctSlider.value = (float)ct / (float)minCt;

}
}
=======


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

        if (Input.GetKey(KeyCode.RightShift) && st > 0)
        {

            isRunnig = true;
            applySpeed = runSpeed;
            st -= std;

        }
        else
        {

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

