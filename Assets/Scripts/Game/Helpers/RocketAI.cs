using UnityEngine;
using System.Collections;

public class RocketAI : MonoBehaviour {

	public Transform Target;

	Transform TR;

	void Start () 
	{
		TR = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Target == null)
			Destroy (gameObject);
		else
		{
			TR.LookAt (Target);
			TR.position += TR.forward * 10 * Time.deltaTime;
			if(Vector3.Distance (TR.position, Target.position) < 1)
			{
				Target.gameObject.GetComponent<Enemy>().ApplyDamage (150);
				Destroy (gameObject);
			}
		}
	}
}
