using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 direction;
    public bool dead { get; protected set; } // 사망 상태

    protected virtual void OnEnable()
    {
        // 사망하지 않은 상태로 시작
        dead = false;
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        Movement();

        //Rotation();
    }


    public void Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        // TransformDirection : 자기가 바라보고 있는 방향으로 이동하는 함수입니다.
        transform.position += transform.TransformDirection(direction) * speed * Time.deltaTime;
    }

    //public void Rotation()
    //{
    //    mouseX += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;

    //    transform.eulerAngles = new Vector3(0, mouseX, 0);
    //}

}
