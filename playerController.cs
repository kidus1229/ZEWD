using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController: MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    private float horizontal;
    private float vertical;

     [SerializeField] public float runSpeed;
      [SerializeField] public float sprintForce;
     [SerializeField] public float jumpForce;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
           
        boxCollider = GetComponent<BoxCollider2D>();       
    }

    // Update is called once per frame
    void Update()
    {    
       vertical = Input.GetAxisRaw("Vertical");
       horizontal = Input.GetAxisRaw("Horizontal");
        if( Input.GetKey("up"))
        {
            Jump();
        }
         
        body.velocity = new Vector2(runSpeed , body.velocity.y);  
       // sprint goes here
         if( Input.GetKey("right"))
        {     
              body.velocity = new Vector2(horizontal*runSpeed* sprintForce , body.velocity.y); 
        }
         
    }

    
     private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

     private void Jump()
    {   if(isGrounded())
        {
        body.velocity = new Vector2(runSpeed , jumpForce);   
    }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bull")
        {
            Debug.Log("I am touching bull");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}

