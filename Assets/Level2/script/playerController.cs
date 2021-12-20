using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController: MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float horizontal;
    private float vertical;

     [SerializeField] public float runSpeed;
      [SerializeField] public float sprintForce;
     [SerializeField] public float jumpForce;

    // [SerializeField] public AudioClip jumpsound;
     //public AudioSource audiosrc;
    

    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();  
        //jumpsound= sound.Load<AudioClip>("jump_sample");
         //audiosrc = GetComponent<AudioSource>();

         //audiosrc.clip = jumpsound;    
    }

    // Update is called once per frame
    void Update()
    {    
       vertical = Input.GetAxisRaw("Vertical");
      
        if( Input.GetKey("up"))
        {
            Jump();
        }
          if( Input.GetKey("down"))
        {
            scrowl();
        }
         
        //body.velocity = new Vector2(runSpeed , body.velocity.y);  
       // sprint goes here
         //if( Input.GetKey("right"))
       // {     
            //  body.velocity = new Vector2(horizontal*runSpeed* sprintForce , body.velocity.y); 
       // }
        anim.SetBool("grounded", isGrounded());
         
    }

    
     private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

     private void Jump()
    {   if(isGrounded())
        { 
         //audioSource.PlayOneShot(jumpsound, 0.7F);
        body.velocity = new Vector2(runSpeed , jumpForce);   
         anim.SetTrigger("jump");
    }
    }   
     private void scrowl()
    {   if(isGrounded())
        {  body.velocity = new Vector2(runSpeed ,-3);   
         anim.SetTrigger("scrowl");
    }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bull")
        {
            Debug.Log("I am touching bull");
            //Displya Game Over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}

