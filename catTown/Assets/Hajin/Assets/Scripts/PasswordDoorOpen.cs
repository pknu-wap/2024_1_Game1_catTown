using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordDoorOpen : MonoBehaviour
{
    CircuitPuzzle circuitPuzzle; // CircuitPuzzle 스크립트에 접근하기 위한 변수
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        circuitPuzzle = GameObject.FindObjectOfType<CircuitPuzzle>();
    }

    void Update()
    {
        // CircuitPuzzle 스크립트에서 is_DoorOpen 변수를 가져와서 확인
        if (circuitPuzzle != null && circuitPuzzle.is_DoorOpen == true)
        {            
            print("Door's Unlocked");
            anim.SetTrigger("Open");
        }
    }
}

