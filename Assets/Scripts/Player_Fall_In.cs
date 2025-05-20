using UnityEngine;
using System.Collections;

public class Player_Fall_In : MonoBehaviour
{
    [SerializeField] private QuestGiver Quest;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    private Vector3 originalPosition;

    void Start()
    {
        // Find and assign components
        animator = GameObject.Find("Player")?.GetComponent<Animator>();
        rb = GameObject.Find("Player")?.GetComponent<Rigidbody2D>();
        boxCollider = GameObject.Find("Player")?.GetComponent<BoxCollider2D>();

        // Store the original position (if you need to reset position later)
        originalPosition = transform.position;

        // Initially disable root motion
        animator.applyRootMotion = true;
    }

    void Update()
    {
        // Optionally check for animation state to handle movement after animation finishes
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FallInWell") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) // Animation is finished
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Quest.QuestRecieved == true && other.CompareTag("Player"))
        {
            // Disable root motion to prevent the animation from moving the player
            StartCoroutine(WaitForRoot());

            // Trigger the animation
            
        }
    }



    IEnumerator WaitForRoot()
    {
        
        animator.SetBool("FallInWell", true);

        // Disable physics-based movement (turn Rigidbody2D to Kinematic)
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Disable the BoxCollider2D to stop interactions
        boxCollider.enabled = false;
        animator.applyRootMotion = false;
        yield return new WaitForSeconds(5f);
        // Optionally, lock the position during animation if needed


    }


}
