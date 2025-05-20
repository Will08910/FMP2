using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    public string sceneName;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        anim1.SetTrigger("OnClick");
        anim2.SetTrigger("OnClick");
        anim3.SetTrigger("OnClick");
        StartCoroutine(GoBack());
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(14f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
