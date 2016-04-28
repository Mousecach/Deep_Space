using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	int HP = 150;
	public int id = 0;
	public int RotationSpeed = 2;

	bool IsDead = false;

	Transform TR;

	Transform Player;

	public void ApplyDamage(int Damage)
	{
		HP -= Damage;
		if( HP <= 0)
		{
			if(!IsDead)
			{
				IsDead = true;
				GameManager.Instance.EnemyDown(id);
			}

			Destroy (gameObject);
		}
	}


	void Start () 
	{
		TR = transform;

		TR.LookAt (new Vector3 (0, 0, 0));

		GameObject[] GO = GameObject.FindGameObjectsWithTag ("Player");
		Player = GO[0].transform;
	}
	
	void FixedUpdate () 
	{
		float Distanse = Vector3.Distance (TR.position, Player.position);

		if(Distanse <= 10)
		{

		}
		else
		{
			TR.position += TR.forward * 0.1f;
			TR.rotation = Quaternion.Slerp(TR.rotation, Quaternion.LookRotation (Player.position - TR.position), RotationSpeed * Time.deltaTime);
		}
	}
}
