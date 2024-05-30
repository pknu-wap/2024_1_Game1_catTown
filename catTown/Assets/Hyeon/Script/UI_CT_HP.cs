using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_CT_HP : MonoBehaviour
{
    public bool isCaution = true;

    // 플레이어 체력 변수
    public int hp = 10; // hp = health point
    public int maxHp = 10;
    public Slider hpSlider;

    // 위험도 변수 제어
    private int ct = 0; // ct = caution
    private float cautionHealthTime = 0.0f;
    private int maxCt = 50;
    private int ctd = 10;
    private int cth = 5;
    public Slider ctSlider;

    void UpdateUI()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isCaution)
        {
        cautionHealthTime += Time.deltaTime;
            if (cautionHealthTime > 5.0f)
            {
                isCaution = true;
            }
        }

        if (isCaution)
        {
            ct += cth;
            
                if (ct > maxCt) {
                    ct = maxCt;
                }    
        }
    
        if (ct < 0 )
        {
            ct = 0;
        } 
        hpSlider.value = (float)hp / maxHp;
        
        ctSlider.value = (float)ct / maxCt;
    }
    
}
