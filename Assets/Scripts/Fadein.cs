using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Fadein : MonoBehaviour
{
    public GameObject textObject;
    public float fadeDuration = 2f;
    public float fadeOutDuration = 1f;
    public TMP_Text textComponent;

    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayCheck());
    }

    IEnumerator FadeTextToFullAlpha()
    {
        yield return new WaitForSeconds(1f);
        float elapsedTime = 0f;
        Color startColor = textComponent.color;
        startColor.a = 0;
        textComponent.color = startColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            startColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            textComponent.color = startColor;
            yield return null;
        }
    }

    IEnumerator DelayCheck()
    {
        yield return new WaitForSeconds(1f);
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(FadeTextToZeroAlpha());
            yield return new WaitForSeconds(1f);
            Destroy(textObject);
        }
    }

    IEnumerator FadeTextToZeroAlpha()
    {
        float elapsedTime = 0f;
        Color startColor = textComponent.color;
        startColor.a = 1;
        textComponent.color = startColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            startColor.a = Mathf.Lerp(1f, 0, elapsedTime / fadeOutDuration);
            textComponent.color = startColor;
            yield return null;
        }
    }
}