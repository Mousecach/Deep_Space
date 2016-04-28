using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int DestroyTime = 10;
	public float Speed = 0.1f;
	public int Damage = 10;

	Transform TR;

	void Start () 
	{
		Destroy (gameObject, DestroyTime);

		TR = transform;
	}

	void FixedUpdate()
	{
		TR.position += TR.forward * Speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			PlayerStatistic PS = col.gameObject.GetComponent<PlayerStatistic>();
			PS.ApplyDamage(Damage);
		}

		if(col.gameObject.tag == "Enemy")
		{
			Enemy enemy = col.gameObject.GetComponent<Enemy>();
			enemy.ApplyDamage(Damage);
		}

		Destroy (gameObject);
	}
}
