using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public Animator transition;


    IEnumerator GoBack()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main Menu");
    }

    public void BackToMenu()
    {
        StartCoroutine(GoBack());
    }

}