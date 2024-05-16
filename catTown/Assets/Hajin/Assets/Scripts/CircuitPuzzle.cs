using UnityEngine;
using UnityEngine.UI;

public class CircuitPuzzle : MonoBehaviour
{
    public Material defaultMaterial; // 기본 매터리얼
    public Material activatedMaterial; // 클릭되었을 때의 매터리얼
    public Renderer[] buttons; // 비밀번호 입력용 버튼들
    public int[] correctPassword; // 올바른 비밀번호

    private int[] inputPassword; // 입력된 비밀번호

    public bool is_DoorOpen = false;

    void Start()
    {
        inputPassword = new int[buttons.Length]; 
        ResetDoor(); 
    }

    void Update()
    {

        if (CheckPassword())
        {
            OpenDoor(); 
        }
    }

    void ResetDoor()
    {
   
        foreach (Renderer button in buttons)
        {
            button.material = defaultMaterial;
        }
        // 초기화
        for (int i = 0; i < inputPassword.Length; i++)
        {
            inputPassword[i] = 0;
        }
    }

    bool CheckPassword()
    {

        for (int i = 0; i < inputPassword.Length; i++)
        {
            if (inputPassword[i] != correctPassword[i])
            {
                return false; 
            }
        }
        return true; 
    }

    void OpenDoor()
    {
        Debug.Log("Door opened!"); 
        is_DoorOpen = true;
    }


public void ButtonClicked(int buttonIndex)
{
    // 버튼의 현재 상태 확인
    if (inputPassword[buttonIndex] == 0)
    {
        // 버튼이 눌리지 않은 상태일 때 클릭
        buttons[buttonIndex].material = activatedMaterial; 
        inputPassword[buttonIndex] = 1; // 클릭
    }
    else
    {
        // 버튼이 이미 눌린 상태일 때 클릭
        buttons[buttonIndex].material = defaultMaterial;
        inputPassword[buttonIndex] = 0; // 클릭 해지
    }
}
}

