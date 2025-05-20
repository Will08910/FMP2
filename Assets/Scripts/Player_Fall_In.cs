using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Fall_In : MonoBehaviour
{
    [SerializeField] private QuestGiver Quest;

    public Animator animator;
    public Animator Transition;

    public Rigidbody2D rb;

    public BoxCollider2D boxCollider;

    private Vector3 originalPosition;

    void Start()
    {
        
        animator = GameObject.Find("Player")?.GetComponent<Animator>();
        rb = GameObject.Find("Player")?.GetComponent<Rigidbody2D>();
        boxCollider = GameObject.Find("Player")?.GetComponent<BoxCollider2D>();

        
        originalPosition = transform.position;

        
        animator.applyRootMotion = true;
    }

    void Update()
    {
       
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FallInWell") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) 
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Quest.QuestRecieved == true && other.CompareTag("Player"))
        {
            
            StartCoroutine(WaitForRoot());

           
            
        }
    }



    IEnumerator WaitForRoot()
    {
        animator.SetBool("FallInWell", true);
        StartCoroutine(Wait());
       
        rb.bodyType = RigidbodyType2D.Kinematic;

        
        boxCollider.enabled = false;
        animator.applyRootMotion = false;
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Act2");
    }


}
