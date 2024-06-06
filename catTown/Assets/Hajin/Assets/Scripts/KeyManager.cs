using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject Key;
    public GameObject previousObject;
    public bool is_keyPossible;

    // Start is called before the first frame update
    void Start()
    {
        Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        is_keyPossible = previousObject.GetComponent<MatScript>().is_keyPossible;

        if (is_keyPossible)
        {
            Debug.Log("Show Key");
            StartCoroutine(ActivateKeyAfterDelay());
        }
    }

    private IEnumerator ActivateKeyAfterDelay()
    {
        yield return new WaitForSeconds(4f); // 0.1초 딜레이
        Key.SetActive(true);
    }
}