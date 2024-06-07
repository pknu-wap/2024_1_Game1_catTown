using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Main_PMove : MonoBehaviour
{
    // 플레이어 이동 속도
    private float walkSpeed = 3f;
    private float runSpeed = 6f;
    private float gravity = -20f;
    private float yVelocity = 0f;

    public bool isRunning = false;
    public bool isStaminaHeal = true; // 불 함수를 통한 스태미너 힐 처리 
    public bool isCaution = true;
    public bool isJumping = false;
    public float jumpPower = 5f;
    public float applySpeed;

    private MeshCollider meshCollider;

    //public bool CameraM = false;

    // 캐릭터 컨트롤러 변수
    CharacterController cc;

    // 플레이어 체력 변수
    public int hp = 10; // hp = health point
    public int maxHp = 10;
    public Slider hpSlider;

    // 플레이어 스태미나 변수
    private int st = 1000;
    private float staminaHealthTime = 0.0f; // 스태미나 힐 딜레이를 위한 타임 기본 값
    private int maxSt = 1000;
    private int std = 10; // stamina damage
    private int sth = 5; // stamina heal
    public Slider stSlider;

    // 위험도 변수 제어
    public int ct = 0; // ct = caution
    public float cautionHealthTime = 0.0f;
    public int maxCt = 100;
    public int ctd = 10;
    public int cth = 5;

    public bool isJody = false;
    
    public Slider ctSlider;



    //[SerializeField] Transform playerRespawnPoint;
    //private Transform playerRespawnPoint;

    // [SerializeField] private float gravitationalAcceleration;
    // [SerializeField] private float jumpForce;

    // private GroundChecker m_groundChecker;
    // private GroundChecker isGrounded;
    // private Vector3 velocity;
    // private bool jumpFlag;

    public int get_ct()
    {
        return ct;
    }

    public int get_maxCt()
    {
        return maxCt;
    }

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        // 캐릭터 컨트롤러 컴포넌트 받아오기
        cc = GetComponent<CharacterController>();
        cc.detectCollisions = false;

        // 속도 초기화
        applySpeed = walkSpeed;
    }

    private void Update()
    {
        // float GetYVelocity()
    
        // {
        // if (!m_groundChecker.IsGrounded())
        // {
        //     return velocity.y - gravitationalAcceleration * Time.fixedDeltaTime;
        // }

        // if (jumpFlag)
        // {
        //     jumpFlag = false;
        //     return velocity.y + jumpForce;
        // }
        // else
        // {
        //     return Mathf.Max(0.0f, velocity.y);
        // };
        // }
        // if (Input.GetButtonDown("Jump")) 
        // {
        //     jumpFlag = true;
        //     isJumping = true;
        // }
        // else
        // {
        //     jumpFlag = false;
        //     isJumping = false;
        //}

        HandleJump();
        HandleMovement();
        HandleSceneSwitching();
        HandleStamina();
        UpdateUI();
        HandleHP();
        Scale();
        if (!isJody)
        {
            HandleCaution();
        }
    }


    void HandleHP()
    {

        if(hp > 10){
            hp = maxHp;
        }
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 플레이어 이동 방향
        Vector3 dir = new Vector3(h, 0, v).normalized;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0; // 수직 방향 제거

        // Shift 키 입력에 따른 달리기 제어 및 스태미나 감소
        if (Input.GetKey(KeyCode.LeftShift) && st > 0 && dir != Vector3.zero) //좌shift로 변경
        {
            isStaminaHeal = false;
            staminaHealthTime = 0.0f; // 스태미나 힐 리셋
            isRunning = true;
            applySpeed = runSpeed;
            st -= std;
        }
        else
        {
            isRunning = false;
            applySpeed = walkSpeed;
        }

        //중력 적용
        if (cc.isGrounded)
        {
            if (isJumping)
            {
                yVelocity = jumpPower;
                isJumping = false;
            }
            else
            {
                yVelocity = 0f;
            }
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }
        dir.y = yVelocity;

        // 캐릭터 이동
        cc.Move(dir * applySpeed * Time.deltaTime);
    }

    void HandleJump()
    {
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void HandleSceneSwitching()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("ApartmentScene");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("constructionSite");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("test");
        }
    }

    void HandleStamina()
    {
        if (!isStaminaHeal)
        {
            staminaHealthTime += Time.deltaTime;
            if (staminaHealthTime > 2.0f)
            {
                isStaminaHeal = true;
            }
        }

        if (isStaminaHeal)
        {
            st += sth;
            if (st < 0) st = 0;
            if (st > maxSt) st = maxSt;
        }

        if(SceneManager.GetActiveScene().name == "constructionSite" )
        {

            st = 2000;
            maxSt =2000;

        }
    }
    
    void HandleCaution()
    {
        if (ct < 0) ct = 0;
        if (ct > maxCt) ct = maxCt;
        if (ct == maxCt)
        {
            Debug.Log("Hello");   
            isJody = true;
            WakeUpJody();
        }
    }

    private void WakeUpJody()
    {
        var jody = GameObject.Find("Jody");
        Debug.Log("You will Die");
        jody.GetComponent<Jody>().wakeUP = true;
    }

    void UpdateUI()
    {
        hpSlider.value = (float)hp / maxHp;
        stSlider.value = (float)st / maxSt;
        ctSlider.value = (float)ct / maxCt;
    }

    void Scale()
    {
        if(Input.GetKey(KeyCode.E))
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            //CameraM = true;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            //CameraM = false;
        }
    }

    // 리스폰
    public void Respawn()
    {
        if (hp <= 0)
        {
            GameObject targetObject = GameObject.Find("Player"); // 변경할 오브젝트의 이름으로 검색
            GameObject playerRespawnManager = GameObject.Find("PlayerRespawn"); // 변경할 오브젝트의 이름으로 검색
            if (targetObject != null)
            {
                // 캐릭터 컨트롤러 비활성화
                cc.enabled = false;
                targetObject.transform.position = playerRespawnManager.transform.position;
                // 캐릭터 컨트롤러 다시 활성화
                cc.enabled = true;
                Debug.Log("위치변경");
                hp = 10;
            }
        }
    }
}