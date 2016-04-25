using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject Bullet;
	public Transform[] SpawnPoint;

	public float ShootingDelay = 1;

	float ShootTime;

	void Start () 
	{
		ShootTime = 0;
	}

	void FixedUpdate () 
	{
		ShootTime -= Time.deltaTime;
		if (ShootTime <= 0) {
			if (Input.GetMouseButton (0)) 
			{
				for(int i = 0; i < SpawnPoint.Length; i++)
				{
					Instantiate (Bullet, SpawnPoint[i].position, SpawnPoint[i].rotation);
					
					ShootTime = ShootingDelay;
				}
			}
		}
	}
}
