using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
