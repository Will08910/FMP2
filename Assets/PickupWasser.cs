using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PickupWasser : MonoBehaviour
{
    [SerializeField] BucketPickUp bucketPickUp;

    public Animator anim;
    public Animator Transition;

    void Start()
    {

    }

    
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (bucketPickUp != null && bucketPickUp.isBucketPickedUp == false && Input.GetKey(KeyCode.E))
            {
                return;
            }

            else if (bucketPickUp != null && bucketPickUp.isBucketPickedUp == true && Input.GetKey(KeyCode.E))
            {
                anim.SetTrigger("Fade");
                StartCoroutine(DelaySceneChange());
            }
        }
    }

    IEnumerator DelaySceneChange()
    {
        yield return new WaitForSeconds(1.5f);
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Act3");
    }
}
