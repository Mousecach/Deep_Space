using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour 
{
	public float MaxForsageSpeed = 40;
	public float MaxFSpeed = 20;
	public int MaxBSpeed = 10;
	public int MaxSSpeed = 6;
	public float dFSpeed = 0.3f;

	float CurrentMaxFSpeed;

	float dBSpeed;
	float CurrentFSpeed = 0;
	float CurrentSSpeed = 0;
	float CurrentVSpeed = 0;

	public KeyCode ForsageButton = KeyCode.LeftShift;

	Transform TR;

	void Start () 
	{
		TR = transform;

		dBSpeed = dFSpeed / 2f;

		CurrentMaxFSpeed = MaxFSpeed;
	}

	void FixedUpdate () 
	{
		if(Input.GetKeyDown(ForsageButton))
		{
			CurrentMaxFSpeed = MaxForsageSpeed;
		}
		if(Input.GetKeyUp(ForsageButton))
		{
			CurrentMaxFSpeed = MaxFSpeed;
		}

		if(Input.GetKey (KeyCode.W))
		{
			if(CurrentFSpeed + dFSpeed <= CurrentMaxFSpeed)
			{
				CurrentFSpeed += dFSpeed;
			}
		}
		else
		{
			if(CurrentFSpeed - dFSpeed >= 0)
			{
				CurrentFSpeed -= dFSpeed;
			}
		}

		if(Input.GetKey (KeyCode.S))
		{
			if(CurrentFSpeed - dBSpeed >= -MaxBSpeed)
			{
				CurrentFSpeed -= dBSpeed;
			}
		}
		else
		{
			if(CurrentFSpeed + dBSpeed <= 0)
			{
				CurrentFSpeed += dBSpeed;
			}
		}

		if(Input.GetKey (KeyCode.D))
		{
			if(CurrentSSpeed + dBSpeed <= MaxSSpeed)
			{
				CurrentSSpeed += dBSpeed;
			}
		}
		else
		{
			if(CurrentSSpeed - dBSpeed >= 0)
			{
				CurrentSSpeed -= dBSpeed;
			}
		}

		if(Input.GetKey (KeyCode.A))
		{
			if(CurrentSSpeed - dBSpeed >= -MaxSSpeed)
			{
				CurrentSSpeed -= dBSpeed;
			}
		}
		else
		{
			if(CurrentSSpeed + dBSpeed <= 0)
			{
				CurrentSSpeed += dBSpeed;
			}
		}

		if(Input.GetKey (KeyCode.Space))
		{
			if(CurrentVSpeed + dBSpeed <= MaxSSpeed)
			{
				CurrentVSpeed += dBSpeed;
			}
		}
		else
		{
			if(CurrentVSpeed - dBSpeed >= 0)
			{
				CurrentVSpeed -= dBSpeed;
			}
		}
		
		if(Input.GetKey (KeyCode.LeftControl))
		{
			if(CurrentVSpeed - dBSpeed >= -MaxSSpeed)
			{
				CurrentVSpeed -= dBSpeed;
			}
		}
		else
		{
			if(CurrentVSpeed + dBSpeed <= 0)
			{
				CurrentVSpeed += dBSpeed;
			}
		}

		Vector3 MoveV = TR.up * CurrentVSpeed * Time.deltaTime;
		Vector3 MoveS = TR.right * CurrentSSpeed * Time.deltaTime;
		Vector3 MoveF = TR.forward * CurrentFSpeed * Time.deltaTime;
		TR.position += (MoveF + MoveS + MoveV);
	}
}
