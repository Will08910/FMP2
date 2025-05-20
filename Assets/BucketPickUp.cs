using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BucketPickUp : MonoBehaviour
{
    public GameObject Bucket;
    [SerializeField] private bool isBucketPickedUp;
    public Animator anim;

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
        }
    }

    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isBucketPickedUp = true;
        }
    }

    public bool IsBucketPickedUp()
    {
        return isBucketPickedUp;
    }

}
