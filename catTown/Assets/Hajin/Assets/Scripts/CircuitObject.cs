using UnityEngine;

public class CircuitObject : MonoBehaviour
{
    public int index; // 인덱스
    public CircuitPuzzle puzzleManager; 

    private Renderer rend; // 오브젝트의 렌더러

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        // 전송
        puzzleManager.OnCircuitButtonClicked(index);
    }
}
