using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public Animator BlackScreenFlicker;
    public Animator ScreenShake;

    private AudioSource audioSource;

    public GameObject StamBar;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Canvas;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StamBar.SetActive(false);
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Canvas.SetActive(false);

            audioSource.Play();
            BlackScreenFlicker.SetTrigger("Jumpscare");
            ScreenShake.SetTrigger("Jumpscare");
            StartCoroutine(Title());
        }
    }

    IEnumerator Title()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
    }
}
