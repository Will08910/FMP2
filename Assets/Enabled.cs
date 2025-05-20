using UnityEngine;

public class Enabled : MonoBehaviour
{

    public GameObject insidePart;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        insidePart.SetActive(!insidePart.activeSelf);

        if (insidePart.activeInHierarchy)
        {
            Screen.fullScreen = true;
        }

        if (!insidePart.activeInHierarchy)
        {
            Screen.fullScreen = false;
        }

    }



}
