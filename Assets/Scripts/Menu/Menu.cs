using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public void CloseApp()
	{
		Application.Quit ();
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
	}
}
