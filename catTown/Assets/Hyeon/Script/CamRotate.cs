using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
        // 회전에 관한 변수
        public float rotSpeed = 200.0f;
        public float CameraSpeed = 10.0f;

        float mx = 0;
        float my = 0;

        // public float offset_x = -0.022f;
        // public float offset_y = 1.249f;
        // public float offset_z = 0.232f;

        // public GameObject Target;
        // Vector3 TargetPosition;

        // public Main_PMove player;

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

    //  if(player.CameraM == true )
    //  {
    //     transform.position = (offset_x, offset_y - 0.5f, offset_z);
    //  }
    //  else
    //  {
    //     transform.position = (offset_x, offset_y, offset_z);
    //  }

    if(player.CameraM == true)
    // {

    //     TargetPosition = new Vector3(
    //         Target.transform.position.x + offset_x,
    //         Target.transform.position.y + offset_y,
    //         Target.transform.position.z + offset_z 
    //         );
        
    //  }
    //  else{
    //     TargetPosition = new Vector3(
    //         Target.transform.position.x + offset_x,
    //         Target.transform.position.y + offset_y,
    //         Target.transform.position.z + offset_z 
    //         );

    //  }

    // transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * CameraSpeed);

    // if(Main_Menu.mm.gState != Main_Menu.GameState.Run)
    // {
    //         return;
    // }
//     Vector3 rot = transform.eulerAngles;
//     rot.x  = Mathf.Clamp(rot.x, -90f, 90f);
//     transform.eulerAngles = rot;
    }
}
