/*
#######################################################
#This script implement the functionality of the boat. #
#                @Leul                                #
#######################################################
*/
//Initialising necessary Modules
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat_script : MonoBehaviour
{
    public Transform boat;
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector2 movement;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
     rb = this.GetComponent<Rigidbody>(); 
     rb.velocity = new Vector2(0,speed);
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
       
    }

    // Update is called once per frame
    void Update()
    {
      moveCharacter(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
  
    }
     
    void moveCharacter(Vector2 direction){
         boat.Translate(direction * speed * Time.deltaTime);
    }
}

