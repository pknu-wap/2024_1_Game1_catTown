using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
        // 회전에 관한 변수
        public float rotSpeed = 200.0f;

        float mx = 0;
        float my = 0;

        float hx = 0;
        float hz = 0;   
    
        float Uh = 1.0f;
        float Dh = 0.2f;

        public GameObject Target;

        public float CameraSpeed = 10.0f;

        Vector3 TargetPosition;


    void Start()
    {
        
    }

    void LateUpdate()
    {
     // 마우스 입력 받음.
     float mouse_X = Input.GetAxis("Mouse X");
     float mouse_Y = Input.GetAxis("Mouse Y");

     //Vector3 dir = new Vector3(-mouse_Y,mouse_X,0);

     // 회전 값 변수 누적

     mx += mouse_X * rotSpeed * Time.deltaTime;
     my += mouse_Y * rotSpeed * Time.deltaTime;

     my = Mathf.Clamp(my, -90f, 90f);

     // 회전 방향으로 물체 회전

     transform.eulerAngles = new Vector3 (-my,mx,0);

    if(Input.GetKey(KeyCode.E)){
        TargetPosition = new Vector3(
            Target.transform.position.x + hx,
            Target.transform.position.y - Dh,
            Target.transform.position.z + hz
            );
        
     }
     else{
        TargetPosition = new Vector3(
            Target.transform.position.x + hx,
            Target.transform.position.y + Uh,
            Target.transform.position.z + hz
            );

     }

     transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * CameraSpeed);

    // if(Main_Menu.mm.gState != Main_Menu.GameState.Run)
    // {
    //         return;
    // }
//     Vector3 rot = transform.eulerAngles;
//     rot.x  = Mathf.Clamp(rot.x, -90f, 90f);
//     transform.eulerAngles = rot;
    }
}
