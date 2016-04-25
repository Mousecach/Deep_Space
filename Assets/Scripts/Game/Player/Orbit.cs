using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public bool OnOrbit = false;
	public GameObject Button;

	public Shooting ST;

	Transform Planet;
	Transform TR;

	MovementController MC;
	RotationController RC;
	//bool PlanetHere = false;
	// Use this for initialization
	void Start () 
	{
		Button.SetActive(false);
		TR = transform;

		MC = GetComponent<MovementController> ();
		RC = GetComponent<RotationController> ();
	}

	void SetControllers(bool Value)
	{
		MC.enabled = Value;
		RC.enabled = Value;
		ST.enabled = Value;
	}

	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.T))
		{
			if(Planet)
			{
				if(TR.parent)
				{
					TR.parent = null;
					OnOrbit = false;

					SetControllers(true);
				}
				else
				{
					TR.parent = Planet;
					OnOrbit = true;

					SetControllers (false);
				}
			}
		}
	}

	void OnTriggerEnter(Collider col) 
	{
		if(col.tag == "Planet")
		{
			Button.SetActive(true);
			Planet = col.transform;
		}
	}

	void OnTriggerExit(Collider col) 
	{
		if(col.tag == "Planet")
		{
			Button.SetActive(false);
			Planet = null;
		}
	}
}
