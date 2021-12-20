using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private BoxCollider2D collider;
    private Rigidbody2D  rb;

    public float scrollSpeed;
    private float width;
    private float horizontal;
     [SerializeField] public float sprint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();            
        collider = GetComponent<BoxCollider2D>(); 
        width= collider.size.x;
       
       rb.velocity = new Vector2(scrollSpeed*sprint,0);
    }

    // Update is called once per frame
    void Update()
    {    horizontal = Input.GetAxisRaw("Horizontal");
         if(horizontal!=0)
           {  Debug.Log("I am touching bull");
              rb.velocity = new Vector2(scrollSpeed * sprint,0);
           }
          rb.velocity = new Vector2(scrollSpeed,0);
        if(transform.position.x < -width*2)
           {
               Vector2 resetPosition = new Vector2(width*2f*3,0);
               transform.position = (Vector2) transform.position + resetPosition;
           }

    }
}
/*
using UnityEngine;
using System.Collections;

public class SimplePlayer : MonoBehaviour {
    
    Animator animator;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool fire = Input.GetButtonDown("Fire1");

        animator.SetFloat("Forward",v);
        animator.SetFloat("Strafe",h);
        animator.SetBool("Fire", fire);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Die");
        }
    }
}


*/