using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsOpen : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;

    public GameObject Scroll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnims()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        anim4.SetTrigger("OnClick");
        anim5.SetTrigger("OnClick");
        yield return new WaitForSeconds(1f);
        Scroll.SetActive(true);
        anim1.SetTrigger("OnClick");
        anim2.SetTrigger("OnClick");
        anim3.SetTrigger("OnClick");

    }
}
