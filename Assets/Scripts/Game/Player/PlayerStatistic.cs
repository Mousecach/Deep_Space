using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour 
{
	[SerializeField]
	int HP = 100;
	[SerializeField]
	int Shield = 100;
	[SerializeField]
	Image HPImage;
	[SerializeField]
	Image ShieldImage;

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
		if(HP < 100 || Shield < 100)
		{
			Delay -= Time.deltaTime;
			if (Delay <= 0) 
			{
				SetDeltaHP(1);
				Delay = EtalonDelay;
			}
		}
		UpdateUI ();
	}

	void SetDeltaHP(int HPDelta)
	{
		if(HPDelta > 0)
		{
			if(HP >= 100)
			{//Нужно восстанавливать щит
				Shield += HPDelta;
				if(Shield > 100)
				{
					Shield = 100;
				}
			}
			else
			{//Нужно восстанавливать жизни
				HP += HPDelta;
				if(HP > 100)
				{
					HP = 100;
				}
			}
		}
		else
		{
			if(Shield == 0)
			{//Нужно отнимать жизни
				HP += HPDelta;
				if (HP <= 0) 
				{
					DIE ();
				}
			}
			else
			{//Отнимаем щит
				Shield += HPDelta;
				if (Shield <= 0) 
				{
					Shield = 0;
				}
			}
		}
	}

	public void Restore()
	{
		HP = 100;
		Shield = 100;
	}

	void UpdateUI()
	{
		ShieldImage.fillAmount = Shield / 100f;
		HPImage.fillAmount = HP / 100f;
	}
}
