using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Animator anim;
    public Animator Transition;
    void Start()
    {
        anim.SetTrigger("Awake");
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main Menu");
    }
}
