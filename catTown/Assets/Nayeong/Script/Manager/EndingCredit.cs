using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    public static EndingCredit Instance;

    GameObject CutScene1;
    GameObject CutScene2;
    GameObject CutScene3;
    GameObject CutScene4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CutScene1= GameObject.Find("MapFirst");
        CutScene2 = GameObject.Find("MapSecond");
        CutScene3 = GameObject.Find("MapThrid");
        CutScene4 = GameObject.Find("LastMessage");
    }


}
