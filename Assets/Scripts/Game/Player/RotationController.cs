using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour 
{
	public float oXRotationSpeed = 60;
	public float oYRotationSpeed = 30;
	public float oZRotationSpeed = 60;

	Transform TR;

	void Start()
	{
		TR = transform;
	}

	void FixedUpdate () 
	{
		float oZRotationCurrentSpeed = 0f;
		if(Input.GetKey(KeyCode.E))
		{
			oZRotationCurrentSpeed = -oZRotationSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.Q))
		{
			oZRotationCurrentSpeed = oZRotationSpeed * Time.deltaTime;
		}

		float oXRotationCurrentSpeed = Input.GetAxis("Mouse Y");
		if(Mathf.Abs(oXRotationCurrentSpeed) > float.Epsilon)
		{
			oXRotationCurrentSpeed *= -oXRotationSpeed * Time.deltaTime;
		}

		float oYRotationCurrentSpeed = Input.GetAxis ("Mouse X");
		if(Mathf.Abs (oYRotationCurrentSpeed) > float.Epsilon)
		{
			oYRotationCurrentSpeed *= oYRotationSpeed * Time.deltaTime;
		}

		TR.Rotate (oXRotationCurrentSpeed, oYRotationCurrentSpeed, oZRotationCurrentSpeed);
	}
}