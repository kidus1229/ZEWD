using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbmvcor : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector2 movement;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("move",2);
    }

    // Update is called once per frame
   public void move(){
rb = this.GetComponent<Rigidbody>(); 
     rb.velocity = new Vector2(-speed,0);
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    
   }
}
