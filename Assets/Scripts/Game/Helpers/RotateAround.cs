using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour 
{
	public Vector3 Rotation;
	Transform TR;

	void Start()
	{
		TR = transform;
	}

	void FixedUpdate () 
	{
		TR.Rotate (Rotation);
	}
}
