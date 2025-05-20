using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BucketPickUp : MonoBehaviour
{
    public GameObject Bucket;
    public GameObject UIStuff1;

    [SerializeField] public bool isBucketPickedUp;

    public Animator anim;
    public Animator UIanim;
    public Animator UIanim2;

    private void Start()
    {
        isBucketPickedUp = false;
        Bucket.SetActive(true);
    }

    private void Update()
    {
        if (isBucketPickedUp == true)
        {
            anim.SetTrigger("BucketPickedUp");
            StartCoroutine(Delay());
            UIanim.SetTrigger("Ob2Activate");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIanim2.SetBool("EToInteract", true);

            if (Input.GetKey(KeyCode.E))
             {
                 isBucketPickedUp = true;
             }

             

        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIanim2.SetBool("EToInteract", false);
        }
        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        UIStuff1.SetActive(false);
    }

}
