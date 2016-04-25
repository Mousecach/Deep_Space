using UnityEngine;
using System.Collections;

public class YouDie : MonoBehaviour {

	public GameObject ScreenDead;
	public GameObject MainUI;

	void Awake()
	{
		//Time.timeScale = 1;
	}

	public void Dead()
	{
		ScreenDead.SetActive(true);
		MainUI.SetActive (false);
		//Time.timeScale = 0;
	}

	public void Restart()
	{
		Application.LoadLevel (1);
	}

	public void ToMainMenu()
	{
		Application.LoadLevel (0);
	}
}
