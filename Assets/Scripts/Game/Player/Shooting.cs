using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject Bullet;
	public GameObject Rocket;

	public Transform RocketSpawnPoint;
	public Transform[] SpawnPoint;

	public float ShootingDelay = 1;
	public Camera camera;

	public bool CanRocket = false;

	float ShootTime;

	void Start () 
	{
		ShootTime = 0;
	}

	void FixedUpdate () 
	{
		ShootTime -= Time.deltaTime;
		if (ShootTime <= 0) 
		{
			if (Input.GetMouseButton (0)) 
			{
				for(int i = 0; i < SpawnPoint.Length; i++)
				{
					Instantiate (Bullet, SpawnPoint[i].position, SpawnPoint[i].rotation);
					
					ShootTime = ShootingDelay;
				}
			}
		}

		Ray ray = camera.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit Hit;
		if (Physics.Raycast(ray, out Hit))
		{
			if (Hit.transform.gameObject.tag == "Enemy")
			{
				CanRocket = true;
				if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.R))
				{
					if(GameManager.Instance.TimeToShoot == 0)
					{
						Object obj = Instantiate (Rocket, RocketSpawnPoint.position, RocketSpawnPoint.rotation);
						RocketAI CurrentEnemy = ((GameObject)obj).GetComponent<RocketAI>();
						CurrentEnemy.Target = Hit.collider.gameObject.transform;
						GameManager.Instance.TimeToShoot = 30;
					}
				}
			}
			else
			{
				CanRocket = false;
			}

		}
		else
		{
			CanRocket = false;
		}
		GameManager.Instance.SetBlinckOnRocketInfo (CanRocket);
	}
}
