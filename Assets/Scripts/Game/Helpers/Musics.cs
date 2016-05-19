using UnityEngine;
using System.Collections;

public class Musics : MonoBehaviour {

	public AudioClip[] Audio;
	AudioSource Source;
	// Use this for initialization
	void Start () 
	{
		Source = GetComponent<AudioSource> ();
		Source.clip = Audio [Random.Range (0, Audio.Length)];
		Source.Play ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(!Source.isPlaying)
		{
			Source.clip = Audio [Random.Range (0, Audio.Length)];
			Source.Play ();
		}
	}
}
