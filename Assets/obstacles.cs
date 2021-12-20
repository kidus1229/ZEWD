using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float respawnTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(obstacleSpawn());   
    }
private void sapawnEnemy(){
    GameObject h = Instantiate(obstacle) as GameObject;
    h.transform.position = new Vector2(Random.Range(-10,10),Random.Range(-206,250));
}
    IEnumerator obstacleSpawn(){
        int num = 15;
        while(num>0){
            yield return new WaitForSeconds(respawnTime);
            sapawnEnemy();
            num--;
        }
    }
}
