using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text text;

	void Start () 
	{
		text = GetComponent<Text> ();
	}

	void FixedUpdate () 
	{
		text.text = GameManager.Instance.Score.ToString ();
	}
}
