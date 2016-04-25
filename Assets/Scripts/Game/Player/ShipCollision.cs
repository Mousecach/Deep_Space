using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {

	PlayerStatistic Player;

	void Start()
	{
		Player = gameObject.GetComponent<PlayerStatistic> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Planet" || col.gameObject.tag == "Destroy")
		{
			Player.ApplyDamage (1000000);
		}
	}
}
