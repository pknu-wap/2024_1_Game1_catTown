using UnityEngine;
using System.Collections.Generic;

public class CircuitPuzzle : MonoBehaviour
{
    public GameObject[] circuitObjects; // 회선 배열
    public GameObject objectToDestroy; 
    public int[] correctSequence; // 정답 회선

    public Material defaultMaterial; // 기본 매터리얼
    public Material clickedMaterial; // 클릭 매터리얼

    private List<int> clickedSequence = new List<int>(); // 클릭된 회선의 순서
    private Renderer[] circuitRenderers; // 회선 오브젝트 렌더러 배열

    private void Awake() // 배열 초기화
    {
        circuitRenderers = new Renderer[circuitObjects.Length];
        for (int i = 0; i < circuitObjects.Length; i++)
        {
            circuitRenderers[i] = circuitObjects[i].GetComponent<Renderer>();
            SetObjectMaterial(i, defaultMaterial); // 기본 매터리얼 설정
        }
    }

    public void OnCircuitButtonClicked(int circuitIndex)
    {
        Debug.Log("Clicked Circuit: " + circuitIndex);
        clickedSequence.Add(circuitIndex); // 인덱스를 순서에 추가

        SetObjectMaterial(circuitIndex, clickedMaterial); // 클릭된 매터리얼

        // 정답 확인
        if (CheckCorrectSequence())
        {
            Debug.Log("Correct Sequence!"); 
            Destroy(objectToDestroy); 
            ResetClickedSequence(); // 초기화
        }
        else if (clickedSequence.Count >= correctSequence.Length)
        {
            Debug.Log("Incorrect Sequence!"); 
            ResetClickedSequence(); // 초기화
        }
    }

    private bool CheckCorrectSequence()
    {
        if (clickedSequence.Count != correctSequence.Length)
        {
            return false; // 오답
        }

        // 순서확인
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (clickedSequence[i] != correctSequence[i])
            {
                return false; // 순서오답
            }
        }

        return true; // 정답
    }

    private void ResetClickedSequence()
    {
        clickedSequence.Clear();
        for (int i = 0; i < circuitObjects.Length; i++)
        {
            SetObjectMaterial(i, defaultMaterial); // 클릭된 매터리얼을 기본 매터리얼로 변경
        }
    }

    private void SetObjectMaterial(int index, Material material)
    {
        circuitRenderers[index].material = material;
    }
}
