using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {

	public GameObject Bullet;
	public Transform[] SpawnPoint;

	public float ShootingDelay = 0.3f;

	float ShootTime;

	void Start () 
	{
		ShootTime = 0;
	}

	void FixedUpdate () 
	{
		ShootTime -= Time.deltaTime;
		if (ShootTime <= 0) {
			for(int i = 0; i < SpawnPoint.Length; i++)
			{
				Instantiate (Bullet, SpawnPoint[i].position, SpawnPoint[i].rotation);
				
				ShootTime = ShootingDelay;
			}
		}
	}
}
