using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour 
{
	[SerializeField]
	int HP = 100;
	[SerializeField]
	Image HPImage;

	public YouDie Die;

	public float EtalonDelay = 1f;

	public GameObject Ship;
	MovementController MC;
	RotationController RC;

	private float Delay = 1f;

	void Start()
	{
		MC = gameObject.GetComponent<MovementController> ();
		RC = gameObject.GetComponent<RotationController> ();
	}

	public void ApplyDamage(int Damage)
	{
		SetDeltaHP (-Damage);
		if(HP <= 0)
		{
			DIE ();
		}
	}

	void DIE()
	{
		Die.Dead();
		Destroy (Ship);
		MC.enabled = false;
		RC.enabled = false;
	}

	void FixedUpdate()
	{
		if(HP < 100)
		{
			Delay -= Time.deltaTime;
			if (Delay <= 0) 
			{
				SetDeltaHP(1);
				Delay = EtalonDelay;
			}
		}
	}

	void SetDeltaHP(int HPDelta)
	{
		HP += HPDelta;
		HPImage.fillAmount = HP / 100f;
	}
}
