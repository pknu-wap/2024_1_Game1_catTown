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
    public bool dead { get; protected set; }

    protected virtual void OnEnable()
    {
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

        transform.position += transform.TransformDirection(direction) * speed * Time.deltaTime;
    }

    //public void Rotation()
    //{
    //    mouseX += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;

    //    transform.eulerAngles = new Vector3(0, mouseX, 0);
    //}

}
