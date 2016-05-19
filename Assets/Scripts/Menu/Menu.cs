using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void Start()
	{
		Cursor.visible = true;
	}

	public void CloseApp()
	{
		Application.Quit ();
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
	}
}
