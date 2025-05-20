using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PressToStart : MonoBehaviour
{
    public GameObject GameObject;

    void Start()
    {
        GameObject.SetActive(false);

        
    }

    
    void Update()
    {
        StartCoroutine(DelayInput());
    }

    void MenuStart()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject.SetActive(true);
        }

        else
        {
            RepeatUntilTrue();
        }
    }

    void RepeatUntilTrue()
    {
        MenuStart();
    }

    private IEnumerator DelayInput()
    {
        yield return new WaitForSeconds(1.3f);
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject.SetActive(true);
        }
    }



}

