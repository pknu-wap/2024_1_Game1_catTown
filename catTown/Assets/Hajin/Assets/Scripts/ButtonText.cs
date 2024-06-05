using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextUpdate : MonoBehaviour
{
    public Button button; // 버튼 오브젝트를 Inspector에서 할당해야 합니다.

    void Start()
    {
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        // 버튼의 자식 오브젝트 중 Text 컴포넌트를 찾습니다.
        Text buttonText = button.GetComponentInChildren<Text>();

        // Text 컴포넌트의 text 속성에 "1"을 할당합니다.
        buttonText.text = "1";
    }
}
