using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int DestroyTime = 10;
	public float Speed = 0.1f;

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

	void OnCollisionEnter(Collision collision)
	{
		//ДОБАВЛЯЕМ ДАМАГУ!!!!

		Destroy (gameObject);
	}
}
