using UnityEngine;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class QuestGiver : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public TMP_Text textComponent;
    public float fadeDuration = 2f;
    public GameObject Image;

    public GameObject contButton;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    public bool playerIsClose;

    [SerializeField] public bool QuestRecieved;

    public float wordSpeed;

    private bool isTyping = false; // Flag to check if typing is in progress

    private void Start()
    {
        contButton.SetActive(false);
        Canvas3.SetActive(true);
        Image.SetActive(false);
        QuestRecieved = false;
        Canvas1.SetActive(false);
        dialoguePanel.SetActive(false); // Ensure the dialogue panel is hidden initially
        index = 0; // Reset the dialogue index at the start
    }

    void Update()
    {
        
        if (!dialoguePanel.activeInHierarchy)
        {
            Image.SetActive(false); 
        }

        // Activate quest on 'E' press while in the trigger area
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }

            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                Image.SetActive(true);
                QuestRecieved = true;
            }
            
        }

        // Manage visibility of Canvas2
        if (dialoguePanel.activeSelf)
        {
            Canvas1.SetActive(false);
            Canvas3.SetActive(false);
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed); 
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        
        else
        {
            zeroText();
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Canvas1.SetActive(true);
            StartCoroutine(FadeTextToFullAlpha());
            playerIsClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeTextToZeroAlpha());
            zeroText();
            playerIsClose = false;
        }
    }


    IEnumerator FadeTextToFullAlpha()
    {
        if (Canvas1.active)
        {
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
            startColor.a = Mathf.Lerp(1f, 0, elapsedTime / fadeDuration);
            textComponent.color = startColor;
            yield return null;
        }

        Canvas1.SetActive(false);
    }
}
