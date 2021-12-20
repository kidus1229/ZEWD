using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public GameObject Object;
    //public Transform SpawnPosition;
	public float timebtwspawn;
	public float startTimeBtwSpawn;
    void Update()
    {
			if (timebtwspawn <= 0)
			{
				Instantiate(Object, transform.position, Quaternion.identity);
			}
			else
			{
				timebtwspawn -= Time.deltaTime;
			}
		}
	}
