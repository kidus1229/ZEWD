using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    //public GameObject collision;
   public AudioSource collision_sound;
   public AudioClip clip;
    //public AudioClip clip2;
   static int attempt = 3;
   public GameObject finish_panel;
   void Start(){
collision_sound = GetComponent<AudioSource>();
}
    public void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.name == "congratulation"){
          SceneManager.LoadScene(9);
         // finish_panel.setActive(true);
          Destroy(gameObject);
          return;
        }
        attempt--;
     collision_sound.Play();
      if(attempt==0){
       Destroy(gameObject);
       return;
     }
     SceneManager.LoadScene("Level_4");
     
    }
}
