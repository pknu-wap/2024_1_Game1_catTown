using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_PRotate : MonoBehaviour
{
        public float rotSpeed = 200f;

        float mx = 0;

    void Start()
    {
        
    }


    void Update()
    {
        
        float mouse_X = Input.GetAxis("Mouse X");

        // 회전 값 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;
    
        // 물제 회전 
        transform.eulerAngles = new Vector3(0, mx, 0);

        // if(Main_Menu.mm.gState != Main_Menu.GameState.Run)
        // {
        //     return;
        // }


    }
}
