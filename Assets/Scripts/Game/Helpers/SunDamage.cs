using UnityEngine;
using System.Collections;

public class SunDamage : MonoBehaviour {

	public int Damage = 1;

	void OnTriggerStay(Collider col) 
	{
		PlayerStatistic Player = col.GetComponent<PlayerStatistic> ();
		if(Player != null)
		{
			Player.ApplyDamage (Damage);
		}
	}
}
