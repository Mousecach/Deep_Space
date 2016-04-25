using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

	public Image Image;
	public Text Text;

	public float Length = 1;

	void FixedUpdate()
	{
		float CurrentValue = Mathf.PingPong (Time.time, Length);

		Color CurrentColor = Image.color;
		CurrentColor.a = CurrentValue;
		Image.color = CurrentColor;

		CurrentColor = Text.color;
		CurrentColor.a = CurrentValue;
		Text.color = CurrentColor;
	}
}
