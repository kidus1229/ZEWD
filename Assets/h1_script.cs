using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h1_script : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public Vector2 movement;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("move",1);
       
    }

    // Update is called once per frame
   public void move(){
    
rb = this.GetComponent<Rigidbody>(); 
rb.rotation = Quaternion.AngleAxis(0,Vector3.up);
     rb.velocity = new Vector2(speed,0);
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    Invoke("moveSwitch",4);
   }
   public void moveSwitch(){
//rb = this.GetComponent<Rigidbody>(); 
     rb.rotation = Quaternion.AngleAxis(180,Vector3.up);
     rb.velocity = new Vector2(-speed,0);
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    Invoke("move",4);
   }
}
