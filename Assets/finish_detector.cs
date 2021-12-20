using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_detector : MonoBehaviour
{
    //public GameObject collision;
   public AudioSource collision_sound;
   public AudioClip clip;
   static int attempt = 3;
   void Start(){
collision_sound = GetComponent<AudioSource>();
   }
    public void OnTriggerEnter(Collider other)
    {
    
       Destroy(gameObject);
    }
}
