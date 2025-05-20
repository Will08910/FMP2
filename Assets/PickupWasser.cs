using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PickupWasser : MonoBehaviour
{
    [SerializeField] BucketPickUp bucketPickUp;
    public GameObject water;

    void Start()
    {

    }

    
    void Update()
    {
        if (bucketPickUp == false && Input.GetKey(KeyCode.E))
        {
            return;
        }

        else if (bucketPickUp == true && Input.GetKey(KeyCode.E))
        {
            water.SetActive(false);
            StartCoroutine(DelaySceneChange());
        }
    }

    IEnumerator DelaySceneChange()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Act3");
    }
}
